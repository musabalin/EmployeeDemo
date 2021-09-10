using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCorePersonelDepartman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePersonelDepartman.Controllers
{
    public class PersonelimController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var result = c.Personels.Include(x => x.Birim).ToList();
            return View(result);
        }
      
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> result = (from x in c.Birims.ToList()
                                           select new SelectListItem
                                           {   Text = x.BirimName,
                                               Value = x.BirimID.ToString()
                                           }).ToList();
            ViewBag.dgr = result;
            return View();
        }
        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            var per = c.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = per;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
