using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.Model;
using VSCore.Concrete;

namespace VSSite.Controllers
{
    public class AboutUsController : Controller
    {
        Context db = new Context();
        // GET: AboutUs
        public ActionResult Index()
        {
            var model = db.AboutUses.FirstOrDefault();
            return View(model);
        }

        public ActionResult Save(int id, string bodyContentUA, string bodyContentEN, string phone1, string phone2, string phone3, string email)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            var cur = db.AboutUses.FirstOrDefault(x => x.Id == id);
            if (cur != null)
            {
                cur.Description = htmlProvider.Export(document);
                cur.DescriptionEn = htmlProvider.Export(documentEn);
                cur.Email = email;
                cur.Phone1 = phone1;
                cur.Phone2 = phone2;
                cur.Phone3 = phone3;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}