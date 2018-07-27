using duzceSozluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace duzceSozluk.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            sozlukVeritabani db = new sozlukVeritabani();
            List<Baslik> baslikList = db.Baslik.ToList();
            ViewBag.basliklar = baslikList;

            return View();
        }


        [HttpPost]
        public ActionResult Index(Kullanici kullanici)
        {
            sozlukVeritabani db = new sozlukVeritabani();
            List<Baslik> baslikList = db.Baslik.ToList();
            ViewBag.basliklar = baslikList;
            var user = db.Kullanici.FirstOrDefault(x => x.nick == kullanici.nick && x.sifre == kullanici.sifre);
            if(user != null)
            {

                Session["Kullanici"] = user;

                //FormsAuthentication.SetAuthCookie(user.nick, false);
                ViewBag.user = user.nick;
                return RedirectToAction("Index","TimeLine");
            }
            else
            {
                ViewBag.message = "hatali";
                return View();
            }
           

        }

        public ActionResult logout()
        {
           Session.Abandon();
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "TimeLine");
        }

    }
}