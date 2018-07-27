using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using duzceSozluk.Models;

namespace duzceSozluk.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string veri)
        {
            sozlukVeritabani db = new sozlukVeritabani();

            string aranan = veri.Substring(1, veri.Length - 1);

            if (veri.Substring(0,1) == "#")
            {
                ViewBag.veri = db.Baslik.Where(x => x.baslik.Contains(aranan.ToString())).ToList();
                TempData["nesne"] = 1;
            }else if (veri.Substring(0, 1) == "$")
            {
                TempData["nesne"] = 2;
                ViewBag.veri = db.Kullanici.Where(x => x.nick.Contains(aranan.ToString())).ToList();
            }else if (veri.Substring(0, 1) == "?")
            {
                TempData["nesne"] = 3;
                ViewBag.veri = db.Entry.Where(x => x.icerik.Contains(aranan.ToString())).ToList();
            }

            List<Baslik> baslikList = db.Baslik.ToList();
            ViewBag.basliklar = baslikList;





            return View();
        }
       
    }
}