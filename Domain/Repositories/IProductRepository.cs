using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get(IEnumerable<Guid> ids);
    }
}
