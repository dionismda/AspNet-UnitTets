using Domain.Entities;
using Domain.Repositories;
using System;

namespace Tests.Repositories
{
    public class FakeDiscountRepository : IDiscountRepository
    {
        public Discount? Get(string code)
        {
            if (code == "123456789")
                return new Discount(10, DateTime.Now.AddDays(5));

            if (code == "987654321")
                return new Discount(10, DateTime.Now.AddDays(-5));

            return null;
        }
    }
}
