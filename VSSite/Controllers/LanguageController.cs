using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace VSSite.Controllers
{
    public class LanguageController : Controller
    {
        /// <summary>
        /// Смена языка
        /// </summary>
        /// <param name="language">Язык</param>
        /// <returns></returns>
        public ActionResult ChoiceOfLanguage(string language)
        {
            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }
            HttpCookie cookie = new HttpCookie("Language") { Value = language };
            Response.Cookies.Add(cookie);
            return null;
        }
    }
}