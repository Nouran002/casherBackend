using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casher.Properties.model
{
    public class Dto
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public float sellingPrice { get; set; } // before sale
        public float Discount { get; set; }
        public float DiscountPrice { get; set; } //after sale
        public float totalPrice { get; set; }//for same product
    }
    public class OrderItemm
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public float sellingPrice { get; set; } // before sale
        public float Discount { get; set; }
        public float DiscountPrice { get; set; } //after sale
        public float totalPrice { get; set; }//for same product
        public int OrderId { get; set; }
        public Orderr order { get; set; }

        public int productId { get; set; }
        public Productt product { get; set; }
    }
}
