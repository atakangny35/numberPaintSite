using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Entity
{
    public class Size:Itable
    {
        public int Id { get; set; }
        public string SizeMetric { get; set; }        
        public ICollection<Product> Products { get; set; }
    }
}
