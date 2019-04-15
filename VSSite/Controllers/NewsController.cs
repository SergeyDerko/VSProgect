using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.Model;
using VSCore.Concrete;
using VSCore.Entity;

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


        public ActionResult NewsAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(string titleUA, string titleEn, string body, string bodyEn, string detailUrl, List<string> videoUrl)
        {

            string bodyHtml = HttpUtility.HtmlDecode(body);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyEn);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            using (Context db = new Context())
            {
                var vidData = new List<Video>();

                foreach (var x in vidData)
                {
                    vidData.Add(new Video
                    {
                        Url = x.Url
                    });
                }

              db.Newses.Add(new News
              {
                  Title = titleUA,
                  TitleEn = titleEn,
                  DateNews = DateTime.Now,
                  Body = htmlProvider.Export(document),
                  BodyEn = htmlProvider.Export(documentEn),
                  DetailUrl = detailUrl,
                  Videos = vidData
              });
              db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (Context context = new Context())
            {
                var toRemove = context.Newses.FirstOrDefault(x => x.NewsId == id);
                if (toRemove != null)
                {
                    context.Newses.Remove(toRemove);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}