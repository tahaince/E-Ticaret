using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Siniflar;
using E_Ticaret.Models.Entity;

namespace E_Ticaret.Controllers
{
    public class AdresController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();

        // GET: Adres

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


            if (Session["MAIL"] != null)
            {
                getdata();
            }
            Class1 cs = new Class1();
            cs.deger7 = db.TBL_ADRES.Where(x => x.UYEID == deger14).ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();

            return View(cs);
        }


        public ActionResult AdresSil(int id)
        {
            var adres = db.TBL_ADRES.Find(id);
            db.TBL_ADRES.Remove(adres);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult AdresEkle()
        //{
        //    var uyemail = (string)Session["Mail"];
        //    var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
        //    var deger11 = degerler.AD;
        //    var deger12 = degerler.SOYAD;
        //    var deger13 = degerler.MAIL;
        //    var deger14 = degerler.ID;

        //    ViewBag.dgr11 = deger11;
        //    ViewBag.dgr12 = deger12;
        //    ViewBag.dgr13 = deger13;
        //    ViewBag.dgr14 = deger14;


        //    if (Session["MAIL"] != null)
        //    {
        //        getdata();
        //    }
        //    Class1 cs = new Class1();
        //    cs.deger7 = db.TBL_ADRES.Where(x => x.UYEID == deger14).ToList();
        //    cs.deger5 = db.TBL_KATEGORI.ToList();

        //    return View(cs);
        //}

        [HttpPost]
        public ActionResult AdresEkle(TBL_ADRES p)
        {

            var adres = db.TBL_ADRES.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
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

        public ActionResult AdresGetir(int id)
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
            cs.deger7 = db.TBL_ADRES.Where(x => x.ID == id).ToList();

            cs.deger5 = db.TBL_KATEGORI.ToList();

            return View(cs);

        }


        public ActionResult AdresGetir2(int id)
        {
            var adres = db.TBL_ADRES.Find(id);

            return View("AdresGetir", adres);

        }



        public ActionResult AdresGuncelle(TBL_ADRES p)
        {
            var adres = db.TBL_ADRES.Find(p.ID);
            adres.BASLIK = p.BASLIK;
            adres.IL = p.IL;
            adres.ILCE = p.ILCE;
            adres.ADRES = p.ADRES;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }



}