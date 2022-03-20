using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using numberPaintSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Controllers
{
    public class ContactController : Controller

    {   private readonly  UserManager<User> userManager;
        public ContactController(UserManager<User> _userManager)
        {
            userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            User user = await userManager.FindByNameAsync("Tranfer35");
          
            return View(user);
        }
    }
}
