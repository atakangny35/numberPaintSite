using AutoMapper;
using numberPaintSite.Models.DTO;
using numberPaintSite.Models.DTO.PictureDto;
using numberPaintSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Custom_Extension
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Product,ProductListWithCategoryModel>();
            CreateMap<ProductListWithCategoryModel,Product>();
            CreateMap<ProductAddModel, Product>();
            CreateMap<Product,ProductAddModel>();
            CreateMap<Product, ProductAddModel>();
            CreateMap<ProductAddModel,Product>();
            CreateMap<ProductUpdateModel, Product>();
            //CreateMap<Product,ProductUpdateModel>();
            CreateMap<Pictures,PictureUpdateModel>();
            CreateMap<PictureUpdateModel,Pictures>();
        }
    }
}
