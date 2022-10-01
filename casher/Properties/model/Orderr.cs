using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casher.Properties.model
{
    public class OrderDetails
    {
        public int CustomerId { get; set; }
        public DateTime date { get; set; }
        public List<OrderItemm> list { get; set; }

    }
    public class Orderr
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string OrderName { get; set; }//عاوزه اعمل كونكات فيها بين  الكاستمر id و الوقت
        public float totalPayment { get; set; }

        public int CustomerId { get; set; }
        public Customerr customer { get; set; }
        public ICollection<OrderItemm> items { get; set; }
    }
}
