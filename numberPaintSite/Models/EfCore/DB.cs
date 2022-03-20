using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using numberPaintSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.EfCore
{
    public class DB:IdentityDbContext<User,Role,int>
    {
        public DB(DbContextOptions<DB> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<Size> Sizes { get; set; }


    }
}
