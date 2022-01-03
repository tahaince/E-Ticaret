using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;

namespace E_Ticaret.Controllers
{
    public class OzelliklerController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Ozellikler
        public ActionResult Index(int id)
        {
            var ozellik = db.TBL_URUNOZELLIK.Where(x=>x.URUNID==id).ToList();
            var urun = db.TBL_URUN.Find(id);
            var urunvb = urun.ID;
            ViewBag.urunvb1 = urunvb;
            return View(ozellik);
        }


        public ActionResult OzellikGetir(int id)
        {
            var ozellik = db.TBL_URUNOZELLIK.Find(id);

            List<SelectListItem> deger1 = (from i in db.TBL_OZELLIK.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.OZELLIKAD,
                                               Value = i.OZELLIKID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View("OzellikGetir",ozellik);
        }


        public ActionResult OzellikGuncelle(TBL_URUNOZELLIK p)
        {
            var ozellik = db.TBL_URUNOZELLIK.Find(p.ID);
            ozellik.OZELLIKVALUE = p.OZELLIKVALUE;
            
            var ozl = db.TBL_OZELLIK.Where(l => l.OZELLIKID == p.TBL_OZELLIK.OZELLIKID).FirstOrDefault();
            ozellik.OZELLIKID = ozl.OZELLIKID;


                db.SaveChanges();
            
            return RedirectToAction("Urun", "PersonelPanel");
        }

        [HttpGet]
        public ActionResult OzellikEkle(int id)
        {
            var ozellik = db.TBL_URUNOZELLIK.Find(id);
            var urun = ozellik.URUNID;

            //ozellik.URUNID = urun;
            List<SelectListItem> deger1 = (from i in db.TBL_OZELLIK.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.OZELLIKAD,
                                               Value = i.OZELLIKID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = urun;
            ViewBag.dgr3 = ozellik.ID;
            return View("OzellikEkle",ozellik);
        }

        [HttpPost]
        public ActionResult OzellikEkle(TBL_URUNOZELLIK p)
        {
            var ozellik = db.TBL_URUNOZELLIK.Find(p.ID);

            var ozl = db.TBL_OZELLIK.Where(l => l.OZELLIKID == p.TBL_OZELLIK.OZELLIKID).FirstOrDefault();
           p.TBL_OZELLIK = ozl;


            db.TBL_URUNOZELLIK.Add(p);
            db.SaveChanges();
            return RedirectToAction("Urun","PersonelPanel");
        }

        public ActionResult OzellikSil(int id)
        {
            var ozellik = db.TBL_URUNOZELLIK.Find(id);
            db.TBL_URUNOZELLIK.Remove(ozellik);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}