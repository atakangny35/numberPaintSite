using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Entity
{
    public class User:IdentityUser<int>
    {
        public string Name { get; set; }
    }
}
