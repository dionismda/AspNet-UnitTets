using Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Commands
{
    [TestClass]
    public class CreateOrderCommandTests
    {
        [TestMethod]
        [TestCategory("Commands")]
        public void Comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            CreateOrderCommand command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "0147852369";
            command.PromoCode = "123456789";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }
    }
}
