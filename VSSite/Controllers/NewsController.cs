using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using VSCore.Concrete;

namespace VSSite.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            Context db = new Context();
            return View(db.Newses.OrderByDescending(x=>x.DateNews));
        }

        [HttpPost]
        public ActionResult Save(string title, string titleEn, string body, string bodyEn, string detailUrl, List<string> videoUrl)
        {
            string bodyHtml = HttpUtility.HtmlDecode(body);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyEn);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            return null;
        }

    }
}