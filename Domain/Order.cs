using System;
using System.Collections.Generic;
using System.Linq;

namespace Domains
{
    public class Order
    {
        public int Id { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; }
        public Cart Cart { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? TotalCostWithDiscount
        {
            get => Cart.Items.Sum(x => x.Product.Cost);
            set
            {
                TotalCostWithDiscount = value;
            }
        }

        public Order(Cart cart, DeliveryInfo deliveryInfo)
        {
            CreatedDate = DateTime.Now;
            Cart = cart;
            DeliveryInfo = deliveryInfo;
            Status = OrderStatus.Processing;
        }

        public Order() { }


    }
}
