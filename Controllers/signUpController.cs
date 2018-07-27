using System;
using duzceSozluk.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace duzceSozluk.Controllers
{
    public class signUpController : Controller
    {
        // GET: signUp
        public ActionResult Index()
        {
            sozlukVeritabani db = new sozlukVeritabani();
            List<Baslik> baslikList = db.Baslik.ToList();
            ViewBag.basliklar = baslikList;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Kullanici kullanici ,HttpPostedFileBase fotograf)
        {
            sozlukVeritabani db = new sozlukVeritabani();
            kullanici.kayit_tarihi = DateTime.UtcNow.Date;
            kullanici.onay = false;
            kullanici.yetkiID = 2;
            kullanici.fotograf= DosyaEkle.ResimEkle(fotograf, "Content", "img"); 
            db.Kullanici.Add(kullanici);
            db.SaveChanges();
            List<Baslik> baslikList = db.Baslik.ToList();
            ViewBag.basliklar = baslikList;
            return View();
        }
    }
}