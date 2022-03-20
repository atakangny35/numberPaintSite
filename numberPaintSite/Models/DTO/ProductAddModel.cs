using numberPaintSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.DTO
{
    public class ProductAddModel
    {
        public ProductAddModel()
        {
            Pictures = new List<Pictures>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Sizeid { get; set; }
        public bool Istok { get; set; }
        public string PictureUrl { get; set; }
        //key        
        public int CategoryId { get; set; }
        public ICollection<Pictures> Pictures { get; set; }
    }
}
