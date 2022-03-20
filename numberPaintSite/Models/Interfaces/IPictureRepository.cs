﻿using numberPaintSite.Models.DTO.PictureDto;
using numberPaintSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Interfaces
{
   public interface IPictureRepository:IGenericRepository<Pictures>
    {
        Task<IEnumerable<PicturesWithProductNameModel>> GetPicturesWithProductName(int? id);
    }
}
