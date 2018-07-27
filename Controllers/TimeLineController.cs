using duzceSozluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace duzceSozluk.Controllers
{
    public class TimeLineController : Controller
    {
        sozlukVeritabani db = new sozlukVeritabani();
        // GET: TimeLine
        public ActionResult Index()
        {
            List<Baslik> baslikList = db.Baslik.ToList();
            ViewBag.basliklar = baslikList;
            
            return View();
        }




        [HttpGet]
        public ActionResult getEntry(int id)
        {
            var entryList = db.Entry.Where(d => d.baslikID == id);
            ViewBag.entryList = entryList;
            ViewBag.basliklar =  db.Baslik.ToList();
            
            ViewBag.begeni = db.Begeni.ToList();

            

            return View("Index");
        }


        [HttpPost]
        public ActionResult setEntry(string kullanici, string icerik, string baslik)
        {
            sozlukVeritabani db = new sozlukVeritabani();
            Entry entry = new Entry();
            var k = db.Kullanici.Where(d => d.nick == kullanici).FirstOrDefault();
            entry.kullaniciID = k.kullaniciID;
            entry.icerik = icerik;
            entry.olusturma_tarihi = DateTime.UtcNow.Date;
            entry.baslikID = Convert.ToInt32(baslik.Split('=')[1]);
            entry.onay = false;
            db.Entry.Add(entry);
            db.SaveChanges();


            Response.Redirect("/timeLine/getEntry?id=" + entry.baslikID);
            return null;
        }









    }
}