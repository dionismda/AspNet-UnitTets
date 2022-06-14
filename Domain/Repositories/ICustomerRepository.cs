using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer? Get(string document);
    }
}
