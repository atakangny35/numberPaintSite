using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Entity
{
    public class Category:Itable
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        //Key
        public ICollection<Product> Products { get; set; }
    }
}
