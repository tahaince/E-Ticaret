using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;

namespace E_Ticaret.Controllers
{
    public class MarkaController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Marka
        public ActionResult Index()
        {
            var marka = db.TBL_MARKA.ToList();

            return View(marka);
        }

        public ActionResult MarkaSil(int id)
        {
            var marka = db.TBL_MARKA.Find(id);
            db.TBL_MARKA.Remove(marka);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MarkaGetir(int id)
        {
            var marka = db.TBL_MARKA.Find(id);
            
            return View("MarkaGetir",marka);
        }

        public ActionResult MarkaGuncelle(TBL_MARKA p)
        {
            var marka = db.TBL_MARKA.Find(p.ID);
            marka.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarkaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MarkaEkle(TBL_MARKA p)
        {
            db.TBL_MARKA.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}