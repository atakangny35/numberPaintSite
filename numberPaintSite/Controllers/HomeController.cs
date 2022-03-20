using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using numberPaintSite.Models;
using numberPaintSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository productRepository;

        public HomeController(ILogger<HomeController> logger , IProductRepository _productRepository)
        {
            _logger = logger;
            productRepository = _productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var a= await productRepository.GetProductswithCategory(null);
                
            return View(a);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
