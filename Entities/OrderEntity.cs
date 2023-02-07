using System;
using System.Collections.Generic;

namespace Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DeliveryInfoEntity DeliveryInfo { get; set; }
        public CartEntity Cart { get; set; }
        public OrderStatusEntity Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? TotalCostWithDiscount { get; set; }

        public OrderEntity(CartEntity cart, DeliveryInfoEntity deliveryInfo)
        {
            CreatedDate = DateTime.Now;
            Cart = cart;
            DeliveryInfo = deliveryInfo;
            Status = OrderStatusEntity.Processing;
        }

        public OrderEntity() { }


    }
}
