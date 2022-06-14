using Domain.Entities;

namespace Domain.Repositories
{
    public interface IDiscountRepository
    {
        Discount? Get(string code);
    }
}
