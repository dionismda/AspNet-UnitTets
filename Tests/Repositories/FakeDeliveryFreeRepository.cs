﻿using Domain.Repositories;

namespace Tests.Repositories
{
    public class FakeDeliveryFreeRepository : IDeliveryFreeRepository
    {
        public decimal Get(string zipcode)
        {
            return 10;
        }
    }
}
