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


        [HttpPost]

        public ActionResult SifremiUnuttum(Email m)
        {
            var uye = db.TBL_UYE.FirstOrDefault(x => x.MAIL == m.mail);
            if(uye!=null)
            {
                Guid rnd = Guid.NewGuid();
                uye.SIFRE = rnd.ToString().Substring(1,6);
                db.SaveChanges();
                try
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Burası aynı kalacak
                    client.Credentials = new NetworkCredential("@gmail.com", "");
                    client.EnableSsl = true;

                    MailMessage msj = new MailMessage(); //Yeni bir MailMesajı oluşturuyoruz
                    msj.From = new MailAddress(m.mail); //iletişim kısmında girilecek mail buaraya gelecektir
                    msj.To.Add("@.com"); //Buraya kendi mail adresimizi yazıyoruz
                                                                //  msj.Subject = m.konu + "" + m.mail; //Buraya iletişim sayfasında gelecek konu ve mail adresini mail içeriğine yazacaktır
                    msj.Body = m.mail; //Mail içeriği burada aktarılacakır
                    client.Send(msj); //Clien sent kısmında gönderme işlemi gerçeklecektir.


                    //Bu kısımdan itibaren sizden kullanıcıya gidecek mail bilgisidir
                    //
                    MailMessage msj1 = new MailMessage();
                    msj1.From = new MailAddress("@gmail.com", "");
                    msj1.To.Add(m.mail); //Buraua iletişim sayfasında gelecek mail adresi gelecktir.
                    msj1.Subject = "Şifre Yenileme Talebi Hakkında";
                    msj1.Body = uye.SIFRE;
                    client.Send(msj1);
                    ViewBag.Succes = "Yeni şifreniz mail adresinize gönderildi"; //Bu kısımlarda ise kullanıcıya bilgi vermek amacı ile olur
                    return View();
                }
                catch (Exception)
                {
                    ViewBag.Error = "Mail Gönderilemedi"; //Bu kısımlarda ise kullanıcıya bilgi vermek amacı ile olur
                    return View();
                }



            }
            else {
                ViewBag.Error = "Mesaj Gönderilken hata olıuştu"; //Bu kısımlarda ise kullanıcıya bilgi vermek amacı ile olur

                Response.Write("<script>alert('Kullanıcı Adı veya Şifre hatalı');</script>");

                return View();

            }


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
