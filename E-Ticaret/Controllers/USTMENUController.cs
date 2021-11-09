using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{

    public class USTMENUController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: USTMENU
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger1 = db.TBL_URUN.ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();

            var uyemail = (string)Session["MAIL"];
            var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
            var deger11 = degerler.AD;
            var deger12 = degerler.SOYAD;
            var deger13 = degerler.MAIL;
            var deger14 = degerler.ID;

            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            ViewBag.dgr13 = deger13;
            ViewBag.dgr14 = deger14;

            return View(cs);
        }
    }
}