using Domain.Commands;
using Domain.Commands.Interfaces;
using Domain.Entities;
using Domain.Handlers.Interfaces;
using Domain.Repositories;
using Domain.Utils;
using Flunt.Notifications;

namespace Domain.Handlers
{
    public class OrderHandler : Notifiable, IHandler<CreateOrderCommand>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(ICustomerRepository customerRepository,
                            IDeliveryFeeRepository deliveryFeeRepository,
                            IDiscountRepository discountRepository,
                            IProductRepository productRepository,
                            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeeRepository = deliveryFeeRepository;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Invalid Order", command);
            }

            Customer customer = _customerRepository.Get(command.Customer);

            Decimal deliveryFee = _deliveryFeeRepository.Get(command.ZipCode);

            Discount discount = _discountRepository.Get(command.PromoCode);

            List<Product> products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();

            Order order = new Order(customer, deliveryFee, discount);
            foreach (var item in command.Items)
            {
                Product product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            AddNotifications(customer.Notifications);
            AddNotifications(order.Notifications);

            if (Invalid)
            {
                return new GenericCommandResult(false, "Failed to generate order", Notifications);
            }

            _orderRepository.Save(order);

            return new GenericCommandResult(true, $"Order {order.Number} generated with success", order);
        }
    }
}
