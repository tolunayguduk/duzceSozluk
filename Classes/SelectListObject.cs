using duzceSozluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace duzceSozluk
{
    public class SelectListObject
    {
        sozlukVeritabani ctx = new sozlukVeritabani();

        public SelectList Yetki(int? id)
        {
            if (id == null)
            {
                return new SelectList(ctx.Yetki, "yetkiID", "yetki1");
            }
            else
            {
                return new SelectList(ctx.Yetki, "yetkiID", "yetki1",id);
            }
        }

    }
}