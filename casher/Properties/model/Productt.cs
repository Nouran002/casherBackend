using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casher.Properties.model
{
    public class ProductDetails
    {
        public string productName { get; set; }
        public String productCode { get; set; }
        public int? productQuantity { get; set; }
        public float? originalPrice { get; set; }
        public float? sellingPrice { get; set; }
        public string notes { get; set; }
        //public float? quantityPrice { get; set; }
        public string ImagePath { get; set; }

        public int id { get; set; }

    }
    public class Productt
    {
        public int id { get; set; }
        public string productName { get; set; }
        public String productCode { get; set; }
        public int? productQuantity { get; set; }
        public float? originalPrice { get; set; }
        public float? sellingPrice { get; set; }
        public string notes { get; set; }
        //public float? quantityPrice { get; set; }
        public string ImagePath { get; set; }
        public int StoretId { get; set; }
        public Storee store { get; set; }
        public ICollection<OrderItemm> items { get; set; }
        public int CategoryId { get; set; }
        public Categoryy category { get; set; }
    }
}
