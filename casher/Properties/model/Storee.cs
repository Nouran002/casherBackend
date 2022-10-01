using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casher.Properties.model
{
    public class Storee
    {
        public int id { get; set; }
        public int producttId { get; set; }
        public int producttQuantity { get; set; }

        public ICollection<Productt> products { get; set; }
    }
}
