using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Entity
{
    public class Pictures:Itable
    {
        public int Id { get; set; }
        [Required]
        public string PictureLink { get; set; }

        //Key
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
