using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class layoutController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: layout
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger1 = db.TBL_URUN.ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();
            


            return View(cs);
        }

        public ActionResult KullaniciLayout()
        {
            Class1 cs = new Class1();
            cs.deger1 = db.TBL_URUN.ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();



            return View(cs);
        }
    }
}