using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.DTO.PictureDto
{
    public class PictureUpdateModel
    {
        public int Id { get; set; }
        [Required]
        public string PictureLink { get; set; }

        //Key
        
    }
}
