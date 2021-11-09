using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
        
    public class DenemeController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Deneme
        public ActionResult Index()
        {

            Class1 cs = new Class1();
            cs.deger1 = db.TBL_URUN.ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();



            return View(cs);
        }

        public ActionResult Index2()
        {

            Class1 cs = new Class1();
            cs.deger1 = db.TBL_URUN.ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();



            return View(cs);
        }
        // GET: Urun
        [HttpGet]
        public ActionResult UrunIndex(int id)
        {




            var urun = db.TBL_URUN.Find(id);
            var deger1 = urun.FOTOGRAF;
            var deger2 = urun.AD;
            var deger3 = urun.ACIKLAMA;
            var deger4 = urun.FIYAT;
            var deger5 = urun.TBL_YORUM;
            var deger6 = urun.KATEGORI;
            var deger7 = urun.ID;
            var deger8 = urun.TBL_MARKA.AD;




            Class1 cs = new Class1();
            cs.deger1 = db.TBL_URUN.Where(x => x.KATEGORI == deger6).ToList();

            cs.deger3 = db.TBL_YORUM.Where(y => y.URUN == id).ToList();

            cs.deger4 = db.TBL_URUNOZELLIK.Where(z => z.URUNID == id).ToList();



            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dr6 = deger6;
            ViewBag.dgr7 = deger7;
            ViewBag.dgr8 = deger8;



            //   return View("Index",urun);
            return View(cs);

        }
        [HttpPost]
        public ActionResult YorumEkle(TBL_YORUM p)

        {
            db.TBL_YORUM.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "layout");


        }



    }
}