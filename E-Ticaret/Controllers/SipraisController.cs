using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class SipraisController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Siprais
        [HttpGet]
        public ActionResult Index()
        {

            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
            var deger11 = degerler.AD;
            var deger12 = degerler.SOYAD;
            var deger13 = degerler.MAIL;
            var deger14 = degerler.ID;

            Class1 cs = new Class1();
            cs.deger1 = db.TBL_URUN.ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();
            cs.deger9 = db.TBL_SEPET.Where(x => x.TBL_UYE.ID == deger14).ToList();
            cs.deger7 = db.TBL_ADRES.Where(x => x.TBL_UYE.ID == deger14).ToList();

            if (Session["MAIL"] != null)
            {
                getdata();


            }

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

        public ActionResult getdata()
        {


            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
            var deger11 = degerler.AD;
            var deger12 = degerler.SOYAD;
            var deger13 = degerler.MAIL;
            var deger14 = degerler.ID;
            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            ViewBag.dgr13 = deger13;
            ViewBag.dgr14 = deger14;
            var toplamadet = db.TBL_SEPET.Where(z => z.TBL_UYE.ID == deger14).Sum(z => z.ADET);
            ViewBag.toplamadet = toplamadet;


            return View();
        }


   



        [HttpPost]
        public ActionResult SiparisOlustur(TBL_SIPARIS p,TBL_SIPARISKALEMI y)
        {

            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
            var deger11 = degerler.AD;
            var deger12 = degerler.SOYAD;
            var deger13 = degerler.MAIL;
            var deger14 = degerler.ID;
            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            ViewBag.dgr13 = deger13;
            ViewBag.dgr14 = deger14;
            var siparis = db.TBL_SIPARIS.ToList();
            
            if(p.SIPARISONAY==true)
            {
                p.DURUMM = true;

            }
            else
            {
                p.DURUMM = false;
            }
            db.TBL_SIPARIS.Add(p);
            y.SIPARISID = p.ID;
            SiparisKalemOlustur(y);
            db.SaveChanges();
            return RedirectToAction("Index", "Urunler");
        }

        [HttpPost]
        public ActionResult SiparisKalemOlustur(TBL_SIPARISKALEMI p)
        {

           
                var uyemail = (string)Session["Mail"];
                var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
                var deger11 = degerler.AD;
                var deger12 = degerler.SOYAD;
                var deger13 = degerler.MAIL;
                var deger14 = degerler.ID;
                var urun = db.TBL_SEPET.Where(x => x.UYE == deger14).ToList();



                foreach (var x in urun)
                {

                    p.URUN = x.URUN;
                    p.ADET = x.ADET;
                    p.TUTAR = x.ADET * x.TBL_URUN.FIYAT;


                    db.TBL_SIPARISKALEMI.Add(p);
                    db.SaveChanges();

                }

                return RedirectToAction("Index", "Siprais");

        }

        public ActionResult SepetSil(int id)
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
            var deger11 = degerler.AD;
            var deger12 = degerler.SOYAD;
            var deger13 = degerler.MAIL;
            var deger14 = degerler.ID;


            var urunler = db.TBL_SEPET.Find(id);
            db.TBL_SEPET.Remove(urunler);

            return View();
        }


        public ActionResult SiparisGoruntule()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYE.FirstOrDefault(z => z.MAIL == uyemail);
            var deger11 = degerler.AD;
            var deger12 = degerler.SOYAD;
            var deger13 = degerler.MAIL;
            var deger14 = degerler.ID;

            getdata();

            Class1 cs = new Class1();

            cs.deger5 = db.TBL_KATEGORI.ToList();
            cs.deger11 = db.TBL_SIPARIS.Where(x => x.UYE == deger14).ToList();
            return View(cs);
        }
        public ActionResult SiparisKalemGorutule(int id)

        {
            getdata();
            Class1 cs = new Class1();
            cs.deger12 = db.TBL_SIPARISKALEMI.Where(x=>x.SIPARISID==id).ToList();
            cs.deger5 = db.TBL_KATEGORI.ToList();
            return View(cs);
        }



            }
}