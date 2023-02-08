using Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public CartViewModel Cart { get; set; }
        public DeliveryInfoModelView DeliveryInfo { get; set; }
        public OrderStatusViewModel Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? TotalCostWithDiscount { get; set; }
        public OrderViewModel(CartViewModel cart, DeliveryInfoModelView deliveryInfo)
        {

            CreatedDate = DateTime.Now;
            Cart = cart;
            DeliveryInfo = deliveryInfo;
            Status = OrderStatusViewModel.Processing;
        }

        public OrderViewModel() { }

    }
}
