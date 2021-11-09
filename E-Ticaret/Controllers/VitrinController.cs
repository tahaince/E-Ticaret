using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;

namespace E_Ticaret.Controllers
{
    public class VitrinController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Vitrin
        public ActionResult Index()
        {
            var urun = db.TBL_URUN.ToList();


            return View(urun);
        }
    }
}