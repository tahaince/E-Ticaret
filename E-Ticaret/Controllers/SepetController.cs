using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
using E_Ticaret.Models.Siniflar;
namespace E_Ticaret.Controllers
{
    public class SepetController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Sepet
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger5 = db.TBL_KATEGORI.ToList();

            var uyemail = (string)Session["Mail"];
            if (Session["Mail"] != null)
            {
                var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
                var deger11 = degerler.AD;
                var deger12 = degerler.SOYAD;
                var deger13 = degerler.MAIL;
                var deger14 = degerler.ID;

                ViewBag.dgr11 = deger11;
                ViewBag.dgr12 = deger12;
                ViewBag.dgr13 = deger13;
                ViewBag.dgr14 = deger14;

                cs.deger9 = db.TBL_SEPET.Where(x => x.TBL_UYE.ID == deger14).ToList();
                var toplamadet = db.TBL_SEPET.Where(z => z.TBL_UYE.ID == deger14).Sum(z => z.ADET);

                var toplamfiyat = 0;
                var sepetUrun = db.TBL_SEPET.Where(z => z.TBL_UYE.ID == deger14).ToList();
                foreach (var item in sepetUrun)
                {
                    var urunfiyat = 0;
                    urunfiyat = Convert.ToInt32(db.TBL_URUN.Where(z => z.ID == item.TBL_URUN.ID).First().FIYAT);

                    var adet = 0;
                    adet = Convert.ToInt32(item.ADET);
                    var aratoplam = adet * urunfiyat;
                    ViewBag.adetbirim = aratoplam;
                    toplamfiyat = toplamfiyat + (urunfiyat * adet);
                }

                var fiyat = db.TBL_SEPET.Where(z => z.TBL_UYE.ID == deger14).Sum(z => z.TBL_URUN.FIYAT);
                ViewBag.toplam = toplamfiyat;



                //var miktar = db.TBL_SEPET.Where(z=>z.TBL_UYE.ID==deger14 && )
                ViewBag.toplamadet = toplamadet;

                return View(cs);
            }
            return RedirectToAction("Index","Login");
            }

        public ActionResult StokArtır(int id)
        {

            var urun = db.TBL_SEPET.Find(id);
            urun.ADET++;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Sil(int id)
        {

            var urun = db.TBL_SEPET.Find(id);
            db.TBL_SEPET.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult StokAzalt(int id)
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
            var deger11 = degerler.AD;
            var deger12 = degerler.SOYAD;
            var deger13 = degerler.MAIL;
            var deger14 = degerler.ID;

            var urun = db.TBL_SEPET.Find(id);
            if (urun.ADET - 1 < 1)
            {
                db.TBL_SEPET.Remove(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                urun.ADET--;
                db.SaveChanges();
                return RedirectToAction("Index");

            }


        }

    }
}