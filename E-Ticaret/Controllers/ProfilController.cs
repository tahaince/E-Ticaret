using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class ProfilController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Profil
        public ActionResult Index()
        {
            Class1 cs = new Class1();

            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
            var deger11 = degerler.AD;
            var deger12 = degerler.SOYAD;
            var deger13 = degerler.MAIL;
            var deger14 = degerler.ID;
            var deger15 = degerler.TELEFON;

            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            ViewBag.dgr13 = deger13;
            ViewBag.dgr14 = deger14;
            ViewBag.dgr15 = deger15;


            cs.deger8= db.TBL_UYE.Where(x => x.ID == deger14).ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();

            return View(cs);
        }
        public ActionResult ProfilGuncelle(TBL_UYE p)
        {


            var uye = db.TBL_UYE.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.TELEFON = p.TELEFON;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}