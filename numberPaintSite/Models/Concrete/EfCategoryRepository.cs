using numberPaintSite.Models.EfCore;
using numberPaintSite.Models.Entity;
using numberPaintSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Concrete
{
    public class EfCategoryRepository  : EfGenericRepository<Category>, ICategoryRepository
    {
        private readonly DB context;
        public EfCategoryRepository(DB dB):base(dB)
        {
            context = dB;
        }

    }
}
