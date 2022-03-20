using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using numberPaintSite.Models.DTO;
using numberPaintSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductRepository context;
        private readonly IMapper mapper;
        public AdminController(IProductRepository context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Products(int? id)
        {
            if (id==null)
            {
                var fulllist = await context.GetProductswithCategory(null);
                
                //var fulllist = mapper.Map<IEnumerable<ProductListWithCategoryModel>>(a);
                return View(fulllist);
            }
            var filtered = await context.GetProductswithCategory(id);
            //var filtered = mapper.Map<IEnumerable<ProductListWithCategoryModel>>(await context.exp(i => i.CategoryId == id));
            return View(filtered);
        }
     
    }
}
