using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Entities
{
    [TestClass]
    public class DiscountTests
    {

        [TestMethod]
        [TestCategory("Domain/Discount")]
        public void Desconto_valido()
        {
            Discount discount = new Discount(10, DateTime.Now.AddDays(5));
            Assert.AreEqual(discount.IsValid(), true);
        }

        [TestMethod]
        [TestCategory("Domain/Discount")]
        public void Desconto_expirado()
        {
            Discount discount = new Discount(10, DateTime.Now.AddDays(-5));
            Assert.AreEqual(discount.IsValid(), false);
        }

        [TestMethod]
        [TestCategory("Domain/Discount")]
        public void Desconto_de_10_quando_nao_estiver_expirado_o_prazo()
        {
            Discount discount = new Discount(10, DateTime.Now.AddDays(5));
            Assert.AreEqual(discount.Value(), 10);
        }

        [TestMethod]
        [TestCategory("Domain/Discount")]
        public void Desconto_de_0_quando_estiver_expirado_o_prazo()
        {
            Discount discount = new Discount(10, DateTime.Now.AddDays(-5));
            Assert.AreEqual(discount.Value(), 0);
        }

    }
}
