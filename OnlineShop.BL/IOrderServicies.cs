using Domains;
using System.Collections.Generic;

namespace OnlineShop.BL
{
    public interface IOrderServicies
    {
        IEnumerable<Order> AllOrders();
        void UpdateOrderStatus(int orderId, OrderStatus status);
        void Add(Order order);
    }
}
