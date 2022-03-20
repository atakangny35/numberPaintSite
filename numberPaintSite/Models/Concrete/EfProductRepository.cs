using Microsoft.EntityFrameworkCore;
using numberPaintSite.Models.DTO;
using numberPaintSite.Models.EfCore;
using numberPaintSite.Models.Entity;
using numberPaintSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Concrete
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        private readonly DB context;

        public EfProductRepository(DB DB):base(DB)
        {
            context = DB;
        }

        public async Task<IEnumerable<ProductListWithCategoryModel>> GetProductswithCategory(int? id)
        {

            //var a = await context.Products.Include(x=>x.Category).ToListAsync();
            if (id == null)
            {
                var b = await (from prd in context.Products
                               join cat in context.Categories on prd.CategoryId equals cat.Id join size in context.Sizes on prd.SizeId equals size.Id
                               where prd.IsDeleted == false
                               select new ProductListWithCategoryModel
                               {
                                   Id = prd.Id,
                                   CategoryName = cat.CategoryName,
                                   Size=size.SizeMetric,
                                   Istok = prd.Istok,
                                   Name = prd.Name,
                                   Price = prd.Price,
                                   PictureUrl = prd.PictureUrl


                               }).ToListAsync();

                return b;
            }
            var c = await (from prd in context.Products
                           join cat in context.Categories on prd.CategoryId equals cat.Id
                           where cat.Id==id && prd.IsDeleted==false
                           select new ProductListWithCategoryModel
                           {
                               Id = prd.Id,
                               CategoryName = cat.CategoryName,
                               
                               Istok = prd.Istok,
                               Name = prd.Name,
                               Price = prd.Price,
                               PictureUrl = prd.PictureUrl


                           }).ToListAsync();

      
            return c;

        }

        public  void SoftDelete(int id)
        {
            var prod =  context.Products.Find(id);
            prod.IsDeleted = true;
            context.SaveChanges();

        }

        /*public async Task<IEnumerable<Product>> GetProductsByCategory*/

    }
}
