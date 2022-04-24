using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyProject.Models.EntityFramework;
using UdemyProject.Models;
namespace UdemyProject.Controllers
{
    public class notController : Controller
    {
        // GET: not
        dbmvcEntities db = new dbmvcEntities();
        public ActionResult Index()
        {
            var not = db.tblnotlars.ToList();
            return View(not);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(tblnotlar tbn)
        {
            db.tblnotlars.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var notlar = db.tblnotlars.Find(id);
            return View("NotGetir", notlar);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model, tblnotlar p, int sinav1 = 0, int sinav2 = 0, int sinav3 = 0, int proje = 0)
        {
            if (model.islem == "HESAPLA")
            {
                int ORTALAMA = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ORTALAMA;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                var snv = db.tblnotlars.Find(p.notid);
                snv.sinav1 = p.sinav1;
                snv.sinav2 = p.sinav2;
                snv.sinav3 = p.sinav3;
                snv.proje = p.proje;
                snv.ortalama = p.ortalama;
                db.SaveChanges();
                return RedirectToAction("Index", "not");
            }
            return View();
        }
    }
}