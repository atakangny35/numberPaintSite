using Microsoft.EntityFrameworkCore;
using numberPaintSite.Models.DTO.PictureDto;
using numberPaintSite.Models.EfCore;
using numberPaintSite.Models.Entity;
using numberPaintSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Concrete
{
    public class EfPictureRepository:EfGenericRepository<Pictures>,IPictureRepository
    {
        private readonly DB dB;

        public EfPictureRepository(DB _dB):base(_dB)
        {
            dB = _dB;
        }

        public async Task<IEnumerable<PicturesWithProductNameModel>> GetPicturesWithProductName(int? id)
        {
            
            if (id != null) 
            { 
                var a = await (from pic in dB.Pictures
                         join pd in dB.Products on pic.ProductId equals pd.Id
                         where pd.Id==id
                         select new PicturesWithProductNameModel 
                         { Id = pic.Id,
                             PictureLink = pic.PictureLink, 
                             ProductName = pd.Name,
                             ProductId=pd.Id
                         
                         }
                  ).ToListAsync();
                return a;
            }
            else
            {
                var a = await (from pic in dB.Pictures
                               join pd in dB.Products on pic.ProductId equals pd.Id
                               select new PicturesWithProductNameModel
                               {
                                   Id = pic.Id,
                                   PictureLink = pic.PictureLink,
                                   ProductName = pd.Name

                               }
                  ).ToListAsync();
                return a;
            }
            
        }
    }
}
