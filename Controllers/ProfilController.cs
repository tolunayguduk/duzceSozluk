using duzceSozluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace duzceSozluk.Controllers
{
    public class ProfilController : Controller
    {
        sozlukVeritabani db = new sozlukVeritabani();

        public ActionResult Index(int id)
        {
            Kullanici k = db.Kullanici.Where(x => x.kullaniciID == id).SingleOrDefault(); 
            ViewBag.basliklar = db.Baslik.ToList();
            ViewBag.KullaniciEntry = db.Entry.Where(x => x.kullaniciID == id).OrderByDescending(x => x.olusturma_tarihi);
            //TODO : Entry lere gelen beğeni sayıları çekilecek


            int entrySayisi = db.Entry.Count(x => x.kullaniciID == k.kullaniciID);
            int baslikSayisi = db.Baslik.Count(x => x.olusturanID == k.kullaniciID);
            int begeniSayisi = db.Begeni.Count(x => x.kullaniciID == k.kullaniciID);
            
            
            ViewBag.entrySayisi = entrySayisi;
            ViewBag.begeniSayisi = begeniSayisi;
            ViewBag.baslikSayisi = baslikSayisi;



            return View(k);
        }
    }
}