using Flunt.Validations;

namespace Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {

            AddNotifications(
                new Contract()
                        .Requires()
                        .IsNotNull(product, "Product", "Invalid Product")
                        .IsGreaterThan(quantity, 0, "Quantity", "Quantity must be greater than 0")
            );

            Product = product;
            Price = product.Price;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }
}
