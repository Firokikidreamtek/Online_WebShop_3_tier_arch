using Domains;
using Entities;
using System.Collections.Generic;

namespace OnlineShop.DB
{
    public interface IOrderBase
    {
        void Add(Order order);
        IEnumerable<OrderEntity> AllOrders();
        void UpdateOrderStatus(int orderId, OrderStatusEntity status);
    }
}
