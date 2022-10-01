using casher.Properties.model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casher.Properties.Controller
{
    [ApiController]
    [Route("Order")]
    //[Route("/api[Controller]")]
    public class OrderrController:ControllerBase
    {
        List<Orderr> orders = new List<Orderr>();
        List<OrderItemm> orderItems = new List<OrderItemm>();
        [HttpPost("createorder")]
        public ActionResult addOrder(OrderDetails o)
        {
            Orderr or = new Orderr();
            or.CustomerId = o.CustomerId;
            or.date = DateTime.Now;
            orders.Add(or);
            foreach (var item in o.list)
            {
                OrderItemm u = new OrderItemm();
                u.productId = item.productId;
                u.quantity = item.quantity;
                u.sellingPrice = item.sellingPrice;
                u.Discount = item.Discount;
                u.DiscountPrice = item.DiscountPrice;
                u.totalPrice = item.totalPrice;
                u.OrderId = or.id;
                orderItems.Add(u);
            }
            return Ok("Done");
        }
    }
}
