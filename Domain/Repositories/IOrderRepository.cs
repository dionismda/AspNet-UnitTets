﻿using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
