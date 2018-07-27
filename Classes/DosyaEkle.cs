using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace duzceSozluk
{
    public class DosyaEkle
    {
        public static string ResimEkle(HttpPostedFileBase resim, string yol, string klasor)
        {
            string resimAd = "Hata";
            string kayitYeri = string.Empty;
            //int boyut = (resim.ContentLength) * 1024;

            try
            {
                string uzanti = Path.GetExtension(resim.FileName).ToLower();
                if (uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    if (resim.ContentLength > 1000000000)
                    {
                        resimAd = "Boyut";
                    }
                    else
                    {
                        Image orjinalResim = Image.FromStream(resim.InputStream);
                        resimAd = Guid.NewGuid() + uzanti;
                        kayitYeri = HttpContext.Current.Server.MapPath("~/" + yol + "/" + klasor + "/" + resimAd);
                        resim.SaveAs(kayitYeri);
                    }
                }
                else
                {
                    resimAd = "Format";
                }


            }
            catch (Exception ex)
            {
                resimAd = "Hata";
            }
            return resimAd;
        }

        public static bool ResimSil(string resim, string yol, string klasor)
        {
            string silmeYeri = string.Empty;
            try
            {
                silmeYeri = HttpContext.Current.Server.MapPath("~/" + yol + "/" + klasor + "/" + resim);
                File.Delete(silmeYeri);
                return true;
            }
            catch (Exception)
            {
                return false;
            }




        }

    }
}