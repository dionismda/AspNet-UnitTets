using Domain.Entities;
using Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Entities
{
    [TestClass]
    public class OrderTests
    {

        private readonly Customer _customer = new Customer("CustomerTest", "email@teste.com.br");
        private readonly Product _product = new Product("ProductTest 1", 10, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Novo_pedido_valido_deve_gerar_um_mumero_com_oito_caractres()
        {
            Order order = new Order(_customer, 0, _discount);
            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Novo_pedido_status_deve_ser_aguardando_pagamento()
        {
            Order order = new Order(_customer, 0, _discount);
            Assert.AreEqual(order.Status, EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Pedido_pago_seu_status_deve_ser_pago()
        {
            Order order = new Order(_customer, 0, null);
            order.AddItem(_product, 1);
            order.Pay(10);
            Assert.AreEqual(order.Status, EOrderStatus.Paid);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            Order order = new Order(_customer, 0, _discount);
            order.Cancel();
            Assert.AreEqual(order.Status, EOrderStatus.Canceled);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Pedido_sem_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            Order order = new Order(_customer, 0, null);
            order.AddItem(null, 10);
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Pedido_com_quantidade_zero_ou_menor_produto_nao_deve_ser_adicionado()
        {
            Order order = new Order(_customer, 0, _discount);
            order.AddItem(_product, 0);
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Pedido_valido_seu_total_deve_ser_50()
        {
            Order order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Pedido_com_desconto_expirado_o_total_do_pedido_deve_ser_60()
        {
            Discount expiredDiscount = new Discount(10, DateTime.Now.AddDays(-5));
            Order order = new Order(_customer, 10, expiredDiscount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Pedido_com_desconto_invalido_o_valor_do_pedido_deve_ser_60()
        {
            Order order = new Order(_customer, 10, null);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Pedido_com_desconto_de_10_o_total_do_pedido_deve_ser_50()
        {
            Order order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Pedido_uma_taxa_de_entrega_de_10_o_total_do_pedido_deve_ser_60()
        {
            Order order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 6);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain/Order")]
        public void Pedido_sem_cliente_o_mesmo_deve_ser_invalido()
        {
            Order order = new Order(null, 0, _discount);
            Assert.AreEqual(order.Valid, false);
        }

    }
}
