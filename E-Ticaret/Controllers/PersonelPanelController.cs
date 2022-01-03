using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
namespace E_Ticaret.Controllers
{
    public class PersonelPanelController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: PersonelPanel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Urun()
        {
            var urun = db.TBL_URUN.ToList();

            return View(urun);
        }

        public ActionResult UrunSil(int id)
        {
           var urun= db.TBL_URUN.Find(id);
            db.TBL_URUN.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Urun");
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBL_KATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBL_MARKA.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()

                                           }).ToList();
            ViewBag.dgr2 = deger2;


            return View();
        }

        public ActionResult UrunEkle(TBL_URUN p)
        {
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            var mrk = db.TBL_MARKA.Where(l => l.ID == p.TBL_MARKA.ID).FirstOrDefault();
            p.TBL_MARKA = mrk;
            p.TBL_KATEGORI = ktg;
            var urun = db.TBL_URUN.Add(p);
            db.SaveChanges();

            return RedirectToAction("Urun");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBL_URUN.Find(id);

            List<SelectListItem> deger1 = (from i in db.TBL_KATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBL_MARKA.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()

                                           }).ToList();
            ViewBag.dgr2 = deger2;

            var deger3= urun.FOTOGRAF;
            ViewBag.dgr3 = deger3;

            return View("UrunGetir",urun);

        }

        public ActionResult UrunGuncelle(TBL_URUN p)
        {
            var urun = db.TBL_URUN.Find(p.ID);
            urun.AD = p.AD;
            urun.DURUM = p.DURUM;
            urun.ACIKLAMA = p.ACIKLAMA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
            urun.FOTOGRAF = p.FOTOGRAF;


            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            var mrk = db.TBL_MARKA.Where(l => l.ID == p.TBL_MARKA.ID).FirstOrDefault();
            p.TBL_MARKA = mrk;
            p.TBL_KATEGORI = ktg;
            db.SaveChanges();
            return RedirectToAction("Urun");
        }

        public  ActionResult StokArtır(int id)
        {

            var urun = db.TBL_URUN.Find(id);
            urun.STOK++;
            db.SaveChanges();
            return RedirectToAction("Urun");
        }


        public ActionResult StokAzalt(int id)
        {

            var urun = db.TBL_URUN.Find(id);
            urun.STOK--;
            db.SaveChanges();
            return RedirectToAction("Urun");
        }

    }
}