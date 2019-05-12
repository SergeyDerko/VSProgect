using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.Model;
using VSCore.Concrete;
using VSCore.Entity;

namespace VSSite.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        Context db = new Context();
        // GET: News
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult NewsAdd()
        {
            return View();
        }

        public ActionResult News_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<News> queryable = db.Newses;
            DataSourceResult result = queryable.ToDataSourceResult(request, news => new
            {
                NewsId = news.NewsId,
                Title = news.Title,
                Body = news.Body,
                Picture = news.Picture,
            });

            return Json(result);
        }


        [HttpPost]
        public ActionResult Save(string titleUa, string titleEn, string body, string bodyEn, string detailUrl, string videoUrl, string pic)
        {

            string bodyHtml = HttpUtility.HtmlDecode(body);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyEn);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            using (Context db = new Context())
            {

              db.Newses.Add(new News
              {
                  Title = titleUa,
                  TitleEn = titleEn,
                  DateNews = DateTime.Now,
                  Body = htmlProvider.Export(document),
                  BodyEn = htmlProvider.Export(documentEn),
                  DetailUrl = detailUrl,
                  Video = videoUrl,
                  Picture = pic
              });
              db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveEdit(int id,string titleUa, string titleEn, string body, string bodyEn, string detailUrl, string videoUrl, string pic)
        {

            string bodyHtml = HttpUtility.HtmlDecode(body);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyEn);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            using (Context db = new Context())
            {

                var news = db.Newses.FirstOrDefault(x => x.NewsId == id);
                if (news !=null)
                {
                    news.Title = titleUa;
                    news.TitleEn = titleEn;
                    news.DateNews = DateTime.Now;
                    news.Body = htmlProvider.Export(document);
                    news.BodyEn = htmlProvider.Export(documentEn);
                    news.DetailUrl = detailUrl;
                    news.Video = videoUrl;
                    news.Picture = pic;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }


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


        public ActionResult EditNews(int id)
        {
            using (Context context = new Context())
            {
                var news = context.Newses.FirstOrDefault(x => x.NewsId == id);
                if (news !=null)
                {
                    return View(news);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }


    }
}