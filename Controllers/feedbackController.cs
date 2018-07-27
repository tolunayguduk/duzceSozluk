using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using duzceSozluk.Models;
namespace duzceSozluk.Controllers
{
    public class feedbackController : Controller
    {
        // GET: feedback
        public ActionResult Index(int kullaniciID, int entryID)
        {
            sozlukVeritabani db = new sozlukVeritabani();
            List<Baslik> baslikList = db.Baslik.ToList();
            ViewBag.basliklar = baslikList;

            ViewBag.entry = db.Entry.Where(x => x.entryID == entryID).FirstOrDefault();
            ViewBag.kullanici = db.Kullanici.Where(x => x.kullaniciID == kullaniciID).FirstOrDefault();
            ViewBag.turler = db.SikayetTur.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Index(Sikayet sikayet)
        {
            sozlukVeritabani db = new sozlukVeritabani();
            db.Sikayet.Add(sikayet);
            db.SaveChanges();
            Response.Redirect("timeLine");
            return null;
        }


    }
}