using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;

namespace E_Ticaret.Controllers
{
    public class PersonelController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Personel
        [HttpGet]
        public ActionResult PersonelLogin()
        {


            return View();
        }


        [HttpPost]
        public ActionResult PersonelLogin(TBL_PERSONEL p)
        {

            var personel = db.TBL_PERSONEL.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (personel != null)
            {
                Session["ADSOYAD"] = personel.ADSOYAD.ToString();


                return RedirectToAction("Index", "PersonelPanel");
            }
            return View();
        }

    }
}