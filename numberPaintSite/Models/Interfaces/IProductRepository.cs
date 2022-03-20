using numberPaintSite.Models.DTO;
using numberPaintSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Interfaces
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<IEnumerable<ProductListWithCategoryModel>> GetProductswithCategory(int? id);
         void SoftDelete(int id);
    }
}
