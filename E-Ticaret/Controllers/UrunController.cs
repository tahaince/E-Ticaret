using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class UrunController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Urun
        [HttpGet]
        public ActionResult Index(int id)
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
            var deger9 = urun.TBL_MARKA.FOTOGRAF;


            if (Session["MAIL"] != null)
            {
                getdata();
            }



            Class1 cs = new Class1();
            cs.deger1 = db.TBL_URUN.Where(x => x.KATEGORI == deger6).ToList();

            cs.deger3 = db.TBL_YORUM.Where(y => y.URUN ==id).ToList();

            cs.deger4 = db.TBL_URUNOZELLIK.Where(z => z.URUNID == id).ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dr6 = deger6;
            ViewBag.dgr7 = deger7;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;




            //   return View("Index",urun);
            return View(cs);

        }
        [HttpPost]
        public ActionResult YorumEkle(TBL_YORUM p)

        {

            db.TBL_YORUM.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "URUNLER");


        }
        [HttpPost]
        public ActionResult Favori(TBL_FAVORI p)

        {
         
            db.TBL_FAVORI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Favori");
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
    }
}