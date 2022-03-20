using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.DTO
{
    public class ProductListWithCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public bool Istok { get; set; }
        public string CategoryName { get; set; } ="das";
        public string PictureUrl { get; set; }
    }
}
