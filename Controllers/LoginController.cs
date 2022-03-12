using AgencyCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AgencyCore.Controllers
{
    public class LoginController : Controller
    {
        Context db = new Context();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admin p)
        {
            var information = db.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (information != null)
            {//işlemler

                var claims = new List<Claim>
               {
                   new Claim(ClaimTypes.Name,p.UserName)
               };
                var useridentity = new ClaimsIdentity(claims,"Login"); // Rolleme ve menü erişim yetkileri için burası değişecek.
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Customer"); // Customerdaki Index aksiyonuna yönlendirsin.

            }

            return View();
        }
    }
}
