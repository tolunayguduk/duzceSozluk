using duzceSozluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace duzceSozluk.Controllers
{
    public class AdminController : Controller
    {
        sozlukVeritabani DB = new sozlukVeritabani();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.begeni = DB.Begeni.ToList();
            ViewBag.entry = DB.Entry.ToList();
            ViewBag.baslıktur = DB.BaslikTur.ToList();
            ViewBag.baslık = DB.Baslik.ToList();
            ViewBag.kullanicisay = DB.Kullanici.ToList();
            ViewBag.kullanici = DB.Kullanici.OrderByDescending(x => x.kayit_tarihi).ToList();
            List<Sikayet> sikayet = DB.Sikayet.ToList(); 
            return View(sikayet);
        }


        #region Şikayet İşlemleri

        public ActionResult Sikayet()
        {
            return View(DB.Sikayet.OrderByDescending(x=>x.sikayetID).ToList());
        }

        public ActionResult Incele(int id)
        {
            Sikayet sikayet = DB.Sikayet.Where(x => x.sikayetID == id).SingleOrDefault();
            
            if (sikayet.durum== true)
            {
                sikayet.durum = false;
               TempData["key"]  = "Islem Bekliyor";
            }
            else
            {
                sikayet.durum = true;
                TempData["key"] = "Incelendi";
            }
            DB.SaveChanges();

            return RedirectToAction("Sikayet");
        }

        public ActionResult EntrySil(int id)
        {
            List<Sikayet> s = DB.Sikayet.Where(x => x.entryID == id).ToList();
            Entry e = DB.Entry.Where(x => x.entryID == id).SingleOrDefault(); 
            foreach (var item in s)
            {
                DB.Sikayet.Remove(item);
            } 
            DB.Entry.Remove(e);
            DB.SaveChanges();
            TempData["key"] = "Şikayetler ve Entry Silindi";
            return RedirectToAction("Sikayet");
        }
        public ActionResult SikayetSil (int id)
        {
            Sikayet s = DB.Sikayet.Where(x => x.sikayetID == id).SingleOrDefault();
            DB.Sikayet.Remove(s);
            DB.SaveChanges();
            TempData["key"] = "Şikayet Silindi";
            return RedirectToAction("Sikayet");
        }

        #endregion

        #region Kullanıcı İşlemleri

        public ActionResult Kullanici()
        {
            return View(DB.Kullanici.ToList());
        }

        public ActionResult KullaniciDuzenle(int id)
        {
            Kullanici k = DB.Kullanici.Where(x => x.kullaniciID == id).SingleOrDefault();
            ViewBag.Yetki = new SelectListObject().Yetki(id); 

            return View(k);
        }
        [HttpPost]
        public ActionResult KullaniciDuzenle(Kullanici data ,HttpPostedFileBase fotograf )
        {
            if (fotograf != null)
            { 
                Kullanici kul = DB.Kullanici.Where(x => x.kullaniciID == data.kullaniciID).SingleOrDefault(); 
                kul.ad = data.ad;
                kul.email = data.email;
                kul.nick = data.nick;
                kul.sifre = data.sifre;
                kul.soyad = data.soyad;
                kul.fotograf= DosyaEkle.ResimEkle(fotograf, "Content", "img");
                kul.yetkiID = data.yetkiID;
                DB.SaveChanges();
                TempData["key"] = "Kullanıcı Düzenlendi";
                return RedirectToAction("Kullanici");
            }
            else
            {
                Kullanici kul = DB.Kullanici.Where(x => x.kullaniciID == data.kullaniciID).SingleOrDefault();
                kul.ad = data.ad;
                kul.email = data.email;
                kul.nick = data.nick;
                kul.sifre = data.sifre;
                kul.soyad = data.soyad; 
                kul.yetkiID = data.yetkiID;
                DB.SaveChanges();
                TempData["key"] = "Kullanıcı Düzenlendi";
                return RedirectToAction("Kullanici");
            }

        }

        public ActionResult KullaniciSil(int id)
        {
            Kullanici k = DB.Kullanici.Where(x => x.kullaniciID == id).SingleOrDefault();
            List<Entry> e = DB.Entry.Where(x => x.kullaniciID == id).ToList();
            List<Baslik> b = DB.Baslik.Where(x => x.Kullanici.kullaniciID == id).ToList();
            List<Sikayet> s = DB.Sikayet.Where(x => x.kullaniciID == id).ToList();
            List<Begeni> begeni = DB.Begeni.Where(x => x.kullaniciID == id).ToList();

            foreach (Entry item in e)
            {
                DB.Entry.Remove(item);
            }
            foreach (Baslik item in b)
            {
                DB.Baslik.Remove(item);
            }
            foreach (Sikayet item in s)
            {
                DB.Sikayet.Remove(item);
            }
            foreach (Begeni item in begeni)
            {
                DB.Begeni.Remove(item);
            } 
            DB.Kullanici.Remove(k);
            DB.SaveChanges();
            TempData["key"] = "Kullanıcı Silindi";
            return RedirectToAction("Kullanici");

        }

        #endregion

        #region Başlık İşlemleri

        public ActionResult Baslik()
        {
            return View(DB.Baslik.ToList());
        }
        public ActionResult BaslikSil(int id)
        {
            List<Entry> e = DB.Entry.Where(x => x.baslikID == id).ToList();
            Baslik b = DB.Baslik.Where(x => x.baslikID == id).SingleOrDefault();
            foreach (Entry item in e)
            {
                DB.Entry.Remove(item);
            }
            DB.Baslik.Remove(b);
            DB.SaveChanges();
            TempData["key"] = "Başlık Silindi";
            return RedirectToAction("Baslik");
        }

        #endregion

        #region Entry İşlemleri

        public ActionResult Entry()
        {
            return View(DB.Entry.ToList());
        }

        public ActionResult EntrySile(int id)
        {
            Entry e = DB.Entry.Where(x => x.entryID == id).SingleOrDefault();
            DB.Entry.Remove(e);
            DB.SaveChanges();
            TempData["key"] = "Entry Silindi";
            return RedirectToAction("Entry");
        }

        #endregion
    }
}