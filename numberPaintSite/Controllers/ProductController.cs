using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using numberPaintSite.Models.DTO;
using numberPaintSite.Models.Entity;
using numberPaintSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace numberPaintSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {


        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private IMapper mapper;
        private readonly IsizeRepository sizeRepository;

        public ProductController(IProductRepository _productRepository, ICategoryRepository _categoryRepository, IsizeRepository _sizeRepository)
        {
            productRepository = _productRepository;
            categoryRepository = _categoryRepository;
            sizeRepository = _sizeRepository;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? id,int page=1)
        {  
            var categories = await categoryRepository.GetAll();
            
                ViewBag.categories = categories;
            if (id == null)
            {
                var prodall = await productRepository.GetProductswithCategory(null);
                prodall =prodall.ToPagedList(page, 5);
                return View(prodall);
            }                     
                var prod = await productRepository.GetProductswithCategory(id);
            prod = prod.ToPagedList(page, 5);
            return View(prod);
        }
        [HttpGet]
        public async Task<IActionResult> NewItem()
        {
            var a = await categoryRepository.GetAll();
            List<SelectListItem> DropdownList = a.Select(x => new SelectListItem { Text = x.CategoryName, Value = x.Id.ToString() }).ToList();
            var sizeList = await sizeRepository.GetAll();
            List<SelectListItem> DropdownsizeList = sizeList.Select(x => new SelectListItem { Text = x.SizeMetric, Value = x.Id.ToString() }).ToList();
            ViewBag.DropdownList = DropdownList;
            ViewBag.DropdownList2 = DropdownsizeList;
            return View();
        }
        [HttpPost]
        public  IActionResult NewItem(ProductAddModel model)
        {
            if (ModelState.IsValid)
            {

                var Product = new Product
                {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    SizeId=model.Sizeid,
                    Istok = model.Istok,
                    Price = model.Price,
                    PictureUrl = model.PictureUrl,
                    Pictures=model.Pictures
                };

                productRepository.add(Product);
                return RedirectToAction("Products","Admin");
            }
            ModelState.AddModelError("", "Urün Kayıt edilemedi");

            return View(model);

            // Console.WriteLine(Prd);


        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var a = await categoryRepository.GetAll();
            List<SelectListItem> DropdownList = a.Select(x => 
            new SelectListItem { Text = x.CategoryName, Value = x.Id.ToString() })
            .ToList();
            var sizeList = await sizeRepository.GetAll();
            List<SelectListItem> DropdownsizeList = sizeList.Select(x => new SelectListItem { Text = x.SizeMetric, Value = x.Id.ToString() }).ToList();
            ViewBag.DropdownList = DropdownList;
            ViewBag.DropdownList2 = DropdownsizeList;
            var Prod= await productRepository.Get(id); 
            
            if (Prod != null)
            {
                ProductUpdateModel mapped = new ProductUpdateModel
                {
                    CategoryId = Prod.CategoryId,
                    Name = Prod.Name,
                    SizeId=Prod.SizeId,
                    Id = Prod.Id,
                    Istok = Prod.Istok,
                    PictureUrl = Prod.PictureUrl,
                    Price = Prod.Price
                };
                return View(mapped);
            }
            return View();
                     
            
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateModel model)
        {
            if (ModelState.IsValid) 
            {
              var Prod= await  productRepository.Get(model.Id);

                Prod.Id = model.Id;
                Prod.SizeId = model.SizeId;
                Prod.CategoryId = model.CategoryId;
                Prod.Istok = model.Istok;
                Prod.Name = model.Name;
                //Prod.Pictures = model.Pictures;
                Prod.PictureUrl = model.PictureUrl;
                Prod.Price = model.Price;

                var isChanged=productRepository.SaveChange();
                if (isChanged)
                {
                    return RedirectToAction("Products", "Admin");
                }                              
            }
            ModelState.AddModelError("", "güncelleme işlemi başarısız");
            return View(model);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == null) 
            {
                return RedirectToAction("Products","Admin");
            }
            productRepository.Delete(await productRepository.Get(id));
            return RedirectToAction("products","Admin");
        }
        public  IActionResult SoftDelete(int id)
        {
            if (id == null)
            {
                return RedirectToAction("products", "Admin");
            }
             productRepository.SoftDelete(id);
            return RedirectToAction("products", "Admin");
        }
        
    }
}
