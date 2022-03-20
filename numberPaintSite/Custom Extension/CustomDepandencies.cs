using Microsoft.Extensions.DependencyInjection;
using numberPaintSite.Models.Concrete;
using numberPaintSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Custom_Extension
{
    public static class CustomDepandencies
    {
        public static void AddDepandencies(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IsizeRepository, EfSizeRepository>();
            services.AddScoped<IPictureRepository, EfPictureRepository>();



            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.Name = "Admin";
                option.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromDays(20);
                option.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;

                option.LoginPath = "/Auth/Login";
            });
        }
    }
}
