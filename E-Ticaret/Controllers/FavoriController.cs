using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class FavoriController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Favori
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
            var deger11 = degerler.AD;
            var deger12 = degerler.SOYAD;
            var deger13 = degerler.MAIL;
            var deger14 = degerler.ID;

            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            ViewBag.dgr13 = deger13;
            ViewBag.dgr14 = deger14;


            Class1 cs = new Class1();
            cs.deger6 = db.TBL_FAVORI.Where(x=>x.UYEID==deger14).ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();
            //var fvr = db.TBL_FAVORI.Find(id);


            return View(cs);
        }

        public ActionResult getdata()
        {


            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
            var deger11 = degerler.AD;
            var deger12 = degerler.SOYAD;
            var deger13 = degerler.MAIL;
            var deger14 = degerler.ID;

            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            ViewBag.dgr13 = deger13;
            ViewBag.dgr14 = deger14;

            return View();
        }

        public ActionResult FavoriSil(int id)
        {
            var urun = db.TBL_FAVORI.Find(id);
            db.TBL_FAVORI.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

    }

   
}