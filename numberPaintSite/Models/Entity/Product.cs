using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Entity
{
    public class Product:Itable
    {/*
        public Product()
        {
            Pictures = new HashSet<Pictures>();
            Category = new Category();
        }
        */
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public  decimal Price { get; set; }
        public bool Istok { get; set; }
        public string PictureUrl { get; set; }
        //key        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Pictures> Pictures  { get; set; }
       
        public int SizeId { get; set; }
        public virtual Size Size { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
