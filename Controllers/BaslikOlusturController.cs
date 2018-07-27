using System;
using duzceSozluk.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace duzceSozluk.Controllers
{
    public class BaslikOlusturController : Controller
    {
        // GET: BaslikOlustur
        //[Authorize]
        public ActionResult Index()
        {

            sozlukVeritabani db = new sozlukVeritabani();
            List<Baslik> baslikList = db.Baslik.ToList();
            ViewBag.basliklar = baslikList;
            List<BaslikTur> turList = db.BaslikTur.ToList();
            ViewBag.turler = turList;


            return View();
        }
        [HttpPost]
        public ActionResult Index(string baslik, string tur, HttpPostedFileBase resim, string olusturan)
        {
            sozlukVeritabani db = new sozlukVeritabani();
            var user = db.Kullanici.Where(x => x.nick == olusturan).FirstOrDefault();
            var baslikTur = db.BaslikTur.FirstOrDefault(x => x.ad == tur);
            Baslik tmpBaslik = new Baslik();
            tmpBaslik.baslik = baslik;
            tmpBaslik.turID = baslikTur.turID;
            tmpBaslik.olusturanID = user.kullaniciID;
            tmpBaslik.olusturma_tarihi = DateTime.UtcNow.Date;
            tmpBaslik.onay = false;
            tmpBaslik.resim = DosyaEkle.ResimEkle(resim, "Content", "img");
            db.Baslik.Add(tmpBaslik);
            db.SaveChanges();
            List<Baslik> baslikList = db.Baslik.ToList();
            ViewBag.basliklar = baslikList;
            List<BaslikTur> turList = db.BaslikTur.ToList();
            ViewBag.turler = turList;

            Response.Redirect("/timeLine/getEntry?id=" + db.Baslik.FirstOrDefault(x => x.baslik == baslik).baslikID);
            return null;
        }
    }
}