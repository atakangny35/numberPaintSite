using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using numberPaintSite.Models.DTO.Auth;
using numberPaintSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace numberPaintSite.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
    
        

        public AuthController(UserManager<User> _userManager, SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {


            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var identityResult = await signInManager.PasswordSignInAsync(user, model.Password, true, false);

                    if (identityResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }

            return View("Login", model);
        }

        public async Task<IActionResult> SignUp()
        {   
            User user = new User()
            {
                UserName = "Tranfer35",
                Email = "gunayatakan3535@gmail.com",
                Name ="Tranfer35",
               
            };
            var result = await userManager.CreateAsync(user,"Hgunay1997");

            var errer = result.Errors;
            if (result.Succeeded)
            {
                
                var role = await userManager.AddToRoleAsync(user, "Admin");

                if (role.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                
            }
            return RedirectToAction("Login", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
