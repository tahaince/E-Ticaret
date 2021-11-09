using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
namespace E_Ticaret.Controllers
{

    public class PersonelKategoriController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: PersonelKategori
        public ActionResult Index(string p)
        {
            var ktg = from x in db.TBL_KATEGORI select x;
            if (!string.IsNullOrEmpty(p))
            {
                ktg = ktg.Where(m => m.AD.Contains(p));
            }

            return View(ktg.ToList());
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = db.TBL_KATEGORI.Find(id);
            db.TBL_KATEGORI.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");


        }


        [HttpGet]
        public ActionResult KategoriEkle()
        {

            return View();


        }


        [HttpPost]
        public ActionResult KategoriEkle(TBL_KATEGORI p)
        {

            var ktg = db.TBL_KATEGORI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");


        }


        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBL_KATEGORI.Find(id);

            return View("KategoriGetir",ktg);


        }

        public ActionResult KategoriGuncelle(TBL_KATEGORI p)
        {
            var ktg = db.TBL_KATEGORI.Find(p.ID);
             ktg.AD =p.AD;
            db.SaveChanges();


            return RedirectToAction("Index");


        }




    }



}