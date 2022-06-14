using Domain.Entities;
using Domain.Repositories;

namespace Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer? Get(string document)
        {
            if (document == "123456789")
                return new Customer("CustomerTeste", "customer@teste.com.br");

            return null;
        }
    }
}
