using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using E_Ticaret.Models;
using E_Ticaret.Models.Entity;
using E_Ticaret.Models.Siniflar;
using Newtonsoft.Json;




namespace E_Ticaret.Controllers
{
    public class AdminController : Controller
    {
        EticaretEntities1 db = new EticaretEntities1();
        // GET: Admin



        public ActionResult Panel()
        {

            //List<Doviz> Curlist = null;

            //WebClient client = new WebClient();
            //var json = client.DownloadString("https://www.doviz.com/api/v1/currencies/all/latest");
            //Curlist = JsonConvert.DeserializeObject<List<Doviz>>(json);
            //return View(Curlist.Take(3).ToList());


            //if (Curlist == null)
            //{
            //    return null;

            //}

            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            decimal dolarsatis = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
            decimal Eurosatis = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

            ViewBag.dolar = String.Format("{0:C}", dolarsatis);
            ViewBag.euro = String.Format("{0:C}", Eurosatis);




            var urun = db.TBL_URUN.Count();
            ViewBag.urun = urun;
            var stok = db.TBL_URUN.Sum(x => x.STOK);
            ViewBag.stok = stok;
            var uye = db.TBL_UYE.Count();
            ViewBag.uye = uye;


            Class1 cs = new Class1();

            cs.deger10 = db.TBL_DESTEK.ToList();

            if (Session["ADMIN"] != null)
            {

                GetData();

            }


            //Session["MAIL"] = admin.MAIL.ToString();
            //var ad = admin.AD;
            //var soyad = admin.SOYAD;
            //var foto = admin.FOTOGRAF;
            //ViewBag.ad = ad;
            //ViewBag.soyad = soyad;
            //ViewBag.foto = foto;
            //return RedirectToAction("Panel", "ADMIN");



            return View(cs);


        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(TBL_ADMIN p)
        {
            var admin = db.TBL_ADMIN.Where(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE).FirstOrDefault();
            if (admin != null)
            {

                Session["ADMIN"] = admin.MAIL.ToString();
                var ad = admin.AD;
                var soyad = admin.SOYAD;
                var foto = admin.FOTOGRAF;
                ViewBag.ad = ad;
                ViewBag.soyad = soyad;
                ViewBag.foto = foto;
                return RedirectToAction("Panel", "ADMIN");

            }



            Response.Write("<script>alert('Kullanıcı Adı veya Şifre hatalı');</script>");

            return View();

        }

        public ActionResult GetData()
        {
            var adminmail = (string)Session["ADMIN"];
            var degerler = db.TBL_ADMIN.FirstOrDefault(z => z.MAIL == adminmail);

            var ad = degerler.AD;
            var soyad = degerler.SOYAD;
            var mail = degerler.MAIL;
            var foto = degerler.FOTOGRAF;



            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.mail = mail;
            ViewBag.foto = foto;
            return View();
        }

        
        public ActionResult Mesaj()
        {
            
            var mesaj = db.TBL_DESTEK.ToList();
            return View(mesaj);


        }


    }
}