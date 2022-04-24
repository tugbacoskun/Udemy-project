using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyProject.Models.EntityFramework;

namespace UdemyProject.Controllers
{
    public class kulupController : Controller
    {
        // GET: kulup
        dbmvcEntities db = new dbmvcEntities();
        public ActionResult Index()
        {
            var kulup = db.tblkuluplers.ToList();
            return View(kulup);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(tblkulupler p2)
        {
            db.tblkuluplers.Add(p2);
            db.SaveChanges();
            return View();

        }

        public ActionResult Sil(int id)
        {
            var kulup = db.tblkuluplers.Find(id);
            db.tblkuluplers.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir (int id)
        {
            var kulup = db.tblkuluplers.Find(id);
            return View("KulupGetir", kulup);
        }
        public ActionResult Guncelle(tblkulupler p)
        {
            var klp = db.tblkuluplers.Find(p.kulupid);
            klp.kulupad = p.kulupad;
            db.SaveChanges();
            return RedirectToAction("Index", "kulup");
        }
    }
}