using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyProject.Models.EntityFramework;

namespace UdemyProject.Controllers
{
    public class ogrenciController : Controller
    {
        // GET: ogrenci
        dbmvcEntities db = new dbmvcEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.tblogrencilers.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.tblkuluplers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kulupad,
                                                 Value = i.kulupid.ToString()
                                             }).ToList();
            ViewBag.degerler = degerler;
            return View();
        }
        [HttpPost]

        public ActionResult YeniOgrenci(tblogrenciler p3)
        {
            var klp = db.tblkuluplers.Where(x => x.kulupid == p3.tblkulupler.kulupid).FirstOrDefault();
            p3.tblkulupler = klp;
            db.tblogrencilers.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil (int id)
        {
            var ogrenci = db.tblogrencilers.Find(id);
            db.tblogrencilers.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir (int id)
        {
            var ogrenci = db.tblogrencilers.Find(id);
            List<SelectListItem> degerler = (from i in db.tblkuluplers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kulupad,
                                                 Value = i.kulupid.ToString()
                                             }).ToList();
            ViewBag.degerler = degerler;

            return View("OgrenciGetir", ogrenci);
        }
        public ActionResult Guncelle(tblogrenciler p)
        {
            var ogr = db.tblogrencilers.Find(p.ogrenciıd);
            ogr.ograd = p.ograd;
            ogr.ogrsoyad = p.ogrsoyad;
            ogr.ogrcinsiyet = p.ogrcinsiyet;
            ogr.ogrfoto = p.ogrfoto;
            ogr.ogrkulup = p.ogrkulup;
            db.SaveChanges();
            return RedirectToAction("Index", "ogrenci");
        }
    }
}