using System.ComponentModel.DataAnnotations;

namespace numberPaintSite.Models.DTO.PictureDto
{
    public class PictureAddModel
    {   [Required]
        public int Id { get; set; }
        
        public string PictureLink { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
