using numberPaintSite.Models.EfCore;
using numberPaintSite.Models.Entity;
using numberPaintSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Concrete
{
    public class EfSizeRepository: EfGenericRepository<Size>,IsizeRepository
    {
        private readonly DB DB;
        public EfSizeRepository(DB dB):base(dB)
        {
            DB = dB;
        }
    }
}
