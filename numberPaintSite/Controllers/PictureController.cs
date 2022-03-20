using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using numberPaintSite.Models.DTO;
using numberPaintSite.Models.DTO.PictureDto;
using numberPaintSite.Models.Entity;
using numberPaintSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Controllers
{
    public class PictureController : Controller
    {
        private readonly IPictureRepository pictureRepository;
        private IMapper mapper;
        

        public PictureController(IPictureRepository _pictureRepository,IMapper _mapper)
        {
            pictureRepository = _pictureRepository;
            mapper = _mapper;
        }
        
        public async Task<IActionResult> Index (int? id)
        {

            if (id != null)
            {
                var Picture = await pictureRepository.GetPicturesWithProductName(id);
               // ViewBag.Productid = Picture.FirstOrDefault().ProductId;
                return View(Picture);
            }

            var PictureFull = await pictureRepository.GetPicturesWithProductName(null);

            return View(PictureFull);
        }
        public  IActionResult AddPicture(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Products", "Admin");
            }
            ViewBag.Productid = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddPicture(PictureAddModel model)
        {
           // if ( 1=1)
           if (ModelState.IsValid)
            {
               var Pictures = new Pictures { ProductId = model.Id, PictureLink = model.PictureLink };
                pictureRepository.add(Pictures);
                var issavet = pictureRepository.SaveChange();
                return RedirectToAction("Product","Admin");
            }
            
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePicture(int id)
        {
           var a=await pictureRepository.Get(id);
           var mapped=   mapper.Map<PictureUpdateModel>(a);
            return View(mapped);

        }
        [HttpPost]
        public async Task<IActionResult> UpdatePicture(PictureUpdateModel model)
        {
            var picture = await pictureRepository.Get(model.Id);

            picture.Id = model.Id;
            picture.PictureLink = model.PictureLink;

           var issaved=  pictureRepository.SaveChange();
            if (issaved)
            {
                return RedirectToAction("Index","Picture",model.Id);
            }
            return View(model);
        }
        public async Task<IActionResult> DeletePicture(int id)
        {
            var picture = await pictureRepository.Get(id);
            pictureRepository.Delete(picture);
            var issaved = pictureRepository.SaveChange();
            if (issaved)
            {
                return RedirectToAction("Index", "Picture");
            }
            return View("Index");
        }
    }
}
