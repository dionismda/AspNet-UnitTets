using Domain.Repositories;

namespace Tests.Repositories
{
    public class FakeDeliveryFreeRepository : IDeliveryFeeRepository
    {
        public decimal Get(string zipcode)
        {
            return 10;
        }
    }
}
