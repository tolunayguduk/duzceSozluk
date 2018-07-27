using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using duzceSozluk.Models;

namespace duzceSozluk.Controllers
{
    public class EntryIslemleriController : Controller
    {
        // GET: EntryIslemleri
        // GET: BEĞENİ ARTTIR
        public ActionResult up(int entryID, int kullaniciID)
        {
            sozlukVeritabani db = new sozlukVeritabani();

            Begeni begeni = new Begeni();
            begeni.entryID = entryID;
            begeni.kullaniciID = kullaniciID;

            db.Begeni.Add(begeni);
            db.SaveChanges();
            Response.Redirect(Request.UrlReferrer.ToString());
            return null;
        }
        public ActionResult down(int entryID, int kullaniciID)
        {
            sozlukVeritabani db = new sozlukVeritabani();

            Begeni begeni = db.Begeni.Where(x => x.entryID == entryID && x.kullaniciID == kullaniciID).FirstOrDefault();



            db.Begeni.Remove(begeni);
            db.SaveChanges();
            Response.Redirect(Request.UrlReferrer.ToString());
            return null;
        }
    }
}