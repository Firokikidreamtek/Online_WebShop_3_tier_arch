using AutoMapper;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BL;
using OnlineShop.DB;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ViewModels;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Const.AdminRoleName)]
    [Authorize(Roles = Const.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrderServicies _orderServicies;
        private readonly IMapper _mapper;

        public OrderController(IOrderServicies orderServicies, IMapper mapper)
        {
            _orderServicies = orderServicies;
            _mapper = mapper;
        }

        public IActionResult Orders()
        {
            var orderViewModel = _mapper.Map<IEnumerable<OrderViewModel>>(_orderServicies.AllOrders());
            return View(orderViewModel);
        }

        public IActionResult GetOrder(int orderId)
        {
            var necessaryOrder = _mapper.Map<OrderViewModel>(_orderServicies.AllOrders().FirstOrDefault(x => x.Id == orderId));
            return View(necessaryOrder);
        }

        [HttpPost]
        public IActionResult UpdateStatusOrder(int orderId, OrderStatusViewModel status)
        {
            _orderServicies.UpdateOrderStatus(orderId, _mapper.Map<OrderStatus>(status));
            return RedirectToAction("Orders");
        }
    }
}
