using Microsoft.AspNetCore.Mvc;
using MvcCorePersonelDepartman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace MvcCorePersonelDepartman.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        public async Task<IActionResult> GirisYap(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name,p.Kullanici)
                };

                var useridetity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridetity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Personelim");
            }
            return View();

        }
    }
}
