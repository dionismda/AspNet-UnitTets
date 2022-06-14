﻿using Domain.Commands;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Repositories;

namespace Tests.Handlers
{
    [TestClass]
    public class OrderHandlerTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderHandlerTests()
        {
            _customerRepository = new FakeCustomerRepository();
            _deliveryFeeRepository = new FakeDeliveryFreeRepository();
            _discountRepository = new FakeDiscountRepository();
            _orderRepository = new FakeOrderRepository();
            _productRepository = new FakeProductRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Cliente_inexistente_o_pedido_nao_deve_ser_gerado()
        {
            // TODO: Implementar
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Cep_invalido_o_pedido_deve_ser_gerado_normalmente()
        {
            // TODO: Implementar
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Promocode_inexistente_o_pedido_deve_ser_gerado_normalmente()
        {
            // TODO: Implementar
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Pedido_sem_itens_o_mesmo_nao_deve_ser_gerado()
        {
            // TODO: Implementar
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
        {
            CreateOrderCommand command = new CreateOrderCommand();
            command.Customer = "12345678";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            OrderHandler handler = new OrderHandler(
                _customerRepository,
                _deliveryFeeRepository,
                _discountRepository,
                _productRepository,
                _orderRepository);

            handler.Handle(command);
            Assert.AreEqual(handler.Valid, true);
        }
    }
}
