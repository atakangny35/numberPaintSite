using numberPaintSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.DTO
{
    public class ProductUpdateModel
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int SizeId { get; set; }
        public bool Istok { get; set; }
        public string PictureUrl { get; set; }
        //key        
        public int CategoryId { get; set; }
        //public virtual ICollection<Pictures> Pictures { get; set; }
    }
}
