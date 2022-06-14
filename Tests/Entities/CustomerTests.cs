using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Entities
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        [TestCategory("Domain/Entities/Customer")]
        public void Criado_um_customer_deve_ser_valido()
        {
            Customer customer = new Customer("CustomerTests", "customer@teste.com.br");
            Assert.AreEqual(customer.Valid, true);
        }

        [TestMethod]
        [TestCategory("Domain/Entities/Customer")]
        public void Criado_um_customer_sem_informar_o_nome_deve_ser_invalido()
        {
            Customer customer = new Customer(null, "customer@teste.com.br");
            Assert.AreEqual(customer.Valid, false);
        }

        [TestMethod]
        [TestCategory("Domain/Entities/Customer")]
        public void Criado_um_customer_com_email_errado_deve_ser_invalido()
        {
            Customer customer = new Customer("CustomerTests", "naoeumeemail");
            Assert.AreEqual(customer.Valid, false);
        }

    }
}
