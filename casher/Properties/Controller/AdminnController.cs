using AutoMapper;
using casher.Properties.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace casher.Properties.Controller
{
    [ApiController]
    [Route("[Controller]")]

    public class AdminnController : ControllerBase
    {

        CasherContext _context;
        IMapper _mapper;
        public AdminnController(CasherContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("AdminRegister")]
        public ActionResult add(AdminRegister a)
        {
            Adminn d = _mapper.Map<Adminn>(a);
            _context.admins.Add(d);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("AdminLogin")]
        public ActionResult Login(AdminLogin log)
        {
            var admin = _context.admins.Where(x => x.email == log.email && x.password == log.password).FirstOrDefault();
            if (admin == null)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(admin);
        }
        [HttpGet("GetAllAdmins")]
        public ActionResult GetAllAdmins()
        {
            return Ok(_context.admins.ToList());
        }

        [HttpPost("AddProduct")]
        public ActionResult AddProduct(ProductDetails p,int catId)
        {

            bool o = _context.products.Any(m => m.id == p.id);
            if (o == true)
            {
                return BadRequest("there is a custmer with same id");
            }
            Productt pro = new Productt();
            pro.productCode = p.productCode;
            pro.productName = p.productName;
            pro.originalPrice = p.originalPrice;
            pro.productQuantity = p.productQuantity;
            pro.sellingPrice = p.sellingPrice;
            pro.ImagePath = p.ImagePath;
            pro.notes = p.notes;
            pro.CategoryId = catId;
            _context.products.Add(pro);
            _context.SaveChanges();
                return Ok("Done");
            

        }
        [HttpPost("UpdateProduct")]
        public ActionResult UpdateProduct([FromQuery] int id, [FromBody] ProductDetails det)
        {
            var l = _context.products.AsNoTracking().Where(c => c.id == id).FirstOrDefault();
            if (l == null)
            {
                return BadRequest("there is no product with this id");
            }
            Productt s = new Productt
            {
                id = id,
                productName = det.productName ?? l.productName,
                productCode = det.productCode ?? l.productCode,
                originalPrice = det.originalPrice ?? l.originalPrice,
                productQuantity = det.productQuantity ?? l.productQuantity,
                ImagePath = det.ImagePath ?? l.ImagePath,
                sellingPrice = det.sellingPrice ?? l.sellingPrice,
                notes = det.notes ?? l.notes
            };
            _context.products.Update(s);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("DeleteProduct")]
        public ActionResult DeleteProduct([FromForm] int id)
        {
            var product = _context.products.Where(s => s.id == id).FirstOrDefault();
            if (product == null)
            {
                return BadRequest("there is no customer with this id");
            }
            _context.products.Remove(product);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpGet("GetCustomer")]
        public ActionResult GetCustomer(int id)
        {
            var cust = _context.customers.Where(s => s.id == id).FirstOrDefault();
            if (cust == null)
            {
                return BadRequest("there is no customer with this id");
            }
            return Ok(cust);

        }

        [HttpGet("GetAllCustomers")]
        public ActionResult getAllCustomers()
        {
            var List = _context.customers.Include(c => c.orders).ThenInclude(v => v.items).ThenInclude(a => a.product)
                .ThenInclude(s => s.category).ToList();
            return Ok(List);
        }
        
        [HttpPost("UpdateCustomer")]
            public ActionResult UpdateCustomer([FromQuery] int id, [FromBody] CustomerRegister reg)
        {
            var u = _context.customers.AsNoTracking().Where(c => c.id == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("there is no customer with this id");
            }
            Customerr c = new Customerr
            {
                id = id,
                name = reg.name ?? u.name,
                email = reg.email ?? u.email,
                password = reg.password ?? u.password,
                phone = reg.phone ?? u.phone,
                address = reg.address ?? u.address
            };
            _context.customers.Update(c);
            _context.SaveChanges();
            return Ok("Done");

        }

        [HttpPost("DeleteCustomer")]
        public ActionResult DeleteCustomer([FromForm] int id)
        {
            var customer = _context.customers.Where(s => s.id == id).FirstOrDefault();
            if (customer == null)
            {
                return BadRequest("there is no customer with this id");
            }
            _context.customers.Remove(customer);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("UpdateCategory")]
        public ActionResult UpdateCategory([FromQuery] int id, [FromBody] catDetails cat)
        {
            var u = _context.categories.AsNoTracking().Where(c => c.id == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("there is no category with this id");
            }
            Categoryy c = new Categoryy
            {
                id = id,
                CategoryName = cat.CategoryName ?? u.CategoryName

            };
            _context.categories.Update(c);
            _context.SaveChanges();
            return Ok("Done");

        }
        [HttpPost("DeleteCategory")]
        public ActionResult DeleteCategory([FromForm] int id)
        {
            var category = _context.products.Where(s => s.id == id).FirstOrDefault();
            if (category == null)
            {
                return BadRequest("there is no Category with this id");
            }
            _context.products.Remove(category);
            _context.SaveChanges();
            return Ok("Done");
        }
        
        [HttpPost("AddCategory")]
        public ActionResult AddCategory(catDetails c)
        {
            bool o = _context.categories.Any(m => m.id == c.id);
            if (o == true)
            {
                return BadRequest("there is a category with same id");
            }
            Categoryy cc = new Categoryy();
            cc.CategoryName = c.CategoryName;
            
                _context.categories.Add(cc);
                _context.SaveChanges();
                return Ok("Done");
            

        }
        [HttpGet("GetAllCategories")]
        public ActionResult GetAllCategories()
        {
            return Ok(_context.categories.ToList());
        }
        [HttpPost("AddInStore")]
        public ActionResult AddInStore(Storee t)
        {
            bool o = _context.stores.Any(m => m.id == t.id);
            if (o == true)
            {
                return BadRequest("there is a product in the store with same id");
            }
            Storee ss = new Storee();
            ss.producttQuantity = t.producttQuantity;
            ss.producttId = t.producttId;

            _context.stores.Add(ss);
            _context.SaveChanges();
            return Ok("Done");


        }
        [HttpGet("getAllProductsFromStore")]
        public ActionResult getProductsOfStore()
        {
            return Ok(_context.stores.ToList());
        }
        
        [HttpPost("UpdateStore")]
        public ActionResult UpdateStore([FromQuery] int id)
        {
            var u = _context.stores.AsNoTracking().Where(c => c.id == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("there is no customer with this id");
            }
            Storee s = new Storee
            {
                id = id,
                producttId = u.producttId,
                producttQuantity=u.producttQuantity
              
            };
            _context.stores.Update(s);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("DeleteFromStore")]
        public ActionResult DeleteFromStore([FromForm] int id)
        {
            var store = _context.stores.Where(s => s.id == id).FirstOrDefault();
            if (store == null)
            {
                return BadRequest("there is no product with this id in store");
            }
            _context.stores.Remove(store);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("AddImage")]
        public ActionResult AddImage(IFormFile file)
        {
            string fullPath = Directory.GetCurrentDirectory() + "/Images";

            string name = DateTime.Now.Ticks.ToString() + file.FileName;

            string filepath = fullPath + "/" + name;

            var stream = new FileStream(filepath, FileMode.Create);

            file.CopyTo(stream);

            return Ok(name);
        }


    }

}
