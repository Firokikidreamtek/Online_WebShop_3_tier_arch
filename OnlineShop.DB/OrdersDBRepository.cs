using AutoMapper;
using Domains;
using Entities;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB
{
    public class OrdersDBRepository : IOrderBase
    {

        private readonly DatabaseContext _databaseContext;
        private readonly IProductBase _productBase;
        private readonly ICartBase _cartBase;
        private readonly IMapper _mapper;




        public OrdersDBRepository(DatabaseContext databaseContext, IProductBase productBase, ICartBase cartBase, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _productBase = productBase;
            _cartBase = cartBase;
            _mapper = mapper;
        }

        public int NextOrderId()
        {
            var allOrders = AllOrders();

            if (allOrders.Any())
            {
                return allOrders.Select(x => x.Id).Max() + 1;
            }
            else
            {
                return 1;
            }
        }

        public IEnumerable<OrderEntity> AllOrders()
        {
            var orders = _databaseContext.Orders.Include(x => x.Cart.Items).ThenInclude(x => x.Product).Include(x => x.DeliveryInfo).AsNoTracking();
            if (orders.Any())
            {
                return orders;
            }
            else
            {
                var newListOfOrders = new List<OrderEntity>();
                return newListOfOrders;
            }
        }

        public void UpdateOrderStatus(int orderId, OrderStatusEntity status)
        {
            var necessaryOrder = AllOrders().FirstOrDefault(x => x.Id == orderId);
            necessaryOrder.Status = status;
            _databaseContext.SaveChanges();
        }

        public void Add(Order order)
        {
            var cart = _cartBase.TryGetByUserId(order.Cart.Items.Any() ? order.Cart.UserId : null);

            var newOrder = _mapper.Map<OrderEntity>(order);
            newOrder.Cart = cart;
            _databaseContext.Orders.Add(newOrder);
            _databaseContext.SaveChanges();

            foreach (var item in order.Cart.Items)
            {
                var productInDB = _productBase.TryGetById(item.Product.Id);
                productInDB.AmountInDb = productInDB.AmountInDb - item.Amount;
            }
            _databaseContext.SaveChanges();
        }
    }
}
