using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyProject.Models.EntityFramework;

namespace UdemyProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        dbmvcEntities db = new dbmvcEntities();
        public ActionResult Index()
        {
            var dersler = db.tblderslers.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(tbldersler p)
        {
            db.tblderslers.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var ders = db.tblderslers.Find(id);
            db.tblderslers.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir (int id)
        {
            var ders = db.tblderslers.Find(id);
            return View("DersGetir", ders);
        }
        public ActionResult Guncelle(tbldersler p)
        {
            var drs = db.tblderslers.Find(p.dersıd);
            drs.dersad = p.dersad;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}