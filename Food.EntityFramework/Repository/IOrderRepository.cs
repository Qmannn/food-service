using System;
using Food.EntityFramework.Entities;

namespace Food.EntityFramework.Repository
{
    public interface IOrderRepository: IRepository<Order>
    {
        Order GetOrder(int userId, DateTime deliveryDate);
    }
}