using Microsoft.AspNetCore.Mvc;
using MvcCorePersonelDepartman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePersonelDepartman.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
       
        public IActionResult Index()
        {
            var result = c.Birims.ToList();
            return View(result);
        }
        public IActionResult YeniBirim()
        {
            return View();

        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
           return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var result = c.Birims.Find(id);
            c.Birims.Remove(result);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult BirimGetir(int id)
        {
            var result = c.Birims.Find(id);
            return View("BirimGetir", result);
        }
        public IActionResult Guncelle(Birim variable)
        {
            var result = c.Birims.Find(variable.BirimID);
            result.BirimName = variable.BirimName;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult BirimDetay(int id)
        {
            var result = c.Personels.Where(x => x.BirimID == id).ToList();
            var brmad = c.Birims.Where(x => x.BirimID == id).Select(y => y.BirimName).FirstOrDefault();
            ViewBag.brm = brmad;
            return View(result);

            

        }
    }
}
