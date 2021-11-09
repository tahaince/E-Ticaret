using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;

namespace E_Ticaret.Controllers
{
   
    public class KayitOlController : Controller
    {

        EticaretEntities1 db = new EticaretEntities1();
        // GET: KayitOl
        [HttpGet]
        public ActionResult Index()
        {


            return View();
        }


        [HttpPost]
        public ActionResult Index(TBL_UYE p)
        {
          
            db.TBL_UYE.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");



        }
    }
}