using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Entity;
using System.Net.Mail;
using System.Net;
using E_Ticaret.Models.Email;

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

            Response.Write("<script>alert('Kullanıcı Adı veya Şifre hatalı');</script>");

            return View();

        }

        [HttpGet]
        public ActionResult SifremiUnuttum()
        {
            return View();
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

            Session["MAIL"] = admin.MAIL.ToString();
            var ad = admin.AD;
            var soyad = admin.SOYAD;
            var foto = admin.FOTOGRAF;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.foto = foto;
            return RedirectToAction("Index","Admin");



        }


    }
}