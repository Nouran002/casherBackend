using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casher.Properties.model
{
    public class catDetails
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
    }
    public class Categoryy
    {
        public int id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Productt> products { get; set; }
    }
}
