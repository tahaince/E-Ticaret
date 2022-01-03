using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
namespace E_Ticaret.Controllers
{
    public class OzellikGenelController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: OzellikGenel
        public ActionResult Index()
        {
            var ozellik = db.TBL_OZELLIK.ToList();

            return View(ozellik);
        }
        [HttpGet]
        public ActionResult OzellikEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OzellikEkle(TBL_OZELLIK p)
        {
            db.TBL_OZELLIK.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OzellikGetir(int id)
        {
            var ozellik = db.TBL_OZELLIK.Find(id);

            return View("OzellikGetir",ozellik);
        }

        public ActionResult OzellikGuncelle(TBL_OZELLIK p)
        {
            var ozellik = db.TBL_OZELLIK.Find(p.OZELLIKID);
            ozellik.OZELLIKAD = p.OZELLIKAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OzellikSil(int id)
        {
            var ozellik = db.TBL_OZELLIK.Find(id);
            db.TBL_OZELLIK.Remove(ozellik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }



}