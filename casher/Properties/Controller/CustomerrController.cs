using AutoMapper;
using casher.Properties.model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casher.Properties.Controller
{
    [ApiController]
    [Route("Customer")]
    //[Route("/api[Controller]")]


    public class CustomerrController:ControllerBase
    {
        CasherContext _context;
        IMapper _mapper;
        public CustomerrController(CasherContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("CustomerRegister")]
        public ActionResult add(CustomerRegister s)
        {
            Customerr c = _mapper.Map<Customerr>(s);
            _context.customers.Add(c);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("CustomerLogin")]
        public ActionResult Login(CustomerLogin log)
        {
            var customer = _context.customers.Where(l => l.email == log.email && l.password == log.password).FirstOrDefault();
            if (customer == null)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(customer);
        }

        [HttpGet("GetAllProducts")]
        public ActionResult GetAllProducts()
        {
            return Ok(_context.products.ToList());
        }
        //[HttpPost("createOrder")]
        //public ActionResult createOrder(OrderDetails d)
        //{
        //    Orderr o = new Orderr();
        //    o.date = DateTime.Now;
        //    o.CustomerId = d.CustomerId;
        //    _context.orders.Add(o);
        //    float sum = 0f;
        //    foreach (var item in d.list)
        //    {
        //        Dto u = new Dto();
        //        u.quantity = item.quantity;
        //        u.sellingPrice = item.sellingPrice;
        //        u.Discount = item.Discount;
        //        u.DiscountPrice = item.DiscountPrice;
        //        u.totalPrice = item.totalPrice;
        //        _context.dtos.Add(u);
        //        sum = sum + ((float)u.quantity * u.totalPrice);
        //        _context.dtos.Add(u);
        //    }
        //    o.totalPayment = sum;
        //    _context.orders.Add(o);
        //    _context.SaveChanges();
        //    return Ok("Done");
        //}
    }
}
