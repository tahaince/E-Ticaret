using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;

namespace E_Ticaret.Controllers
{
    public class LoginController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }



            [HttpPost]
        public ActionResult Index(TBL_UYE p)
        {
            var uye = db.TBL_UYE.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if(uye!=null)
            {
                Session["MAIL"] = uye.MAIL.ToString();
                TempData["AD"] = uye.AD.ToString();
                return RedirectToAction("Index","URUNLER");


            }
            return View();

        }
    }
}