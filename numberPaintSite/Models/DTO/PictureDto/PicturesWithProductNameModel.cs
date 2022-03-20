using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.DTO.PictureDto
{
    public class PicturesWithProductNameModel
    {
        public int Id { get; set; }
        [Required]
        public string PictureLink { get; set; }

        //Key
        [Required]
        public string ProductName { get; set; }
        public int ProductId { get; set; }
    }
}
