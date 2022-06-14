using Domain.Entities;
using Domain.Repositories;

namespace Tests.Repositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
        }
    }
}
