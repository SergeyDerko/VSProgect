using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class UsefulController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UsefulList()
        {
            return View();
        }

        public ActionResult UsefulRubricses_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<UsefulRubrics> usefulrubricses = db.UsefulRubricses;
            DataSourceResult result = usefulrubricses.ToDataSourceResult(request, usefulRubrics => new {
                RubricsId = usefulRubrics.RubricsId,
                RubName = usefulRubrics.RubName,
                RubNameEu = usefulRubrics.RubNameEu,
                Picture = usefulRubrics.Picture
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UsefulRubricses_Create([DataSourceRequest]DataSourceRequest request, UsefulRubrics usefulRubrics)
        {
            if (ModelState.IsValid)
            {
                var entity = new UsefulRubrics
                {
                    RubName = usefulRubrics.RubName,
                    RubNameEu = usefulRubrics.RubNameEu,
                    Picture = usefulRubrics.Picture
                };

                db.UsefulRubricses.Add(entity);
                db.SaveChanges();
                usefulRubrics.RubricsId = entity.RubricsId;
            }

            return Json(new[] { usefulRubrics }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UsefulRubricses_Update([DataSourceRequest]DataSourceRequest request, UsefulRubrics usefulRubrics)
        {
            if (ModelState.IsValid)
            {
                var entity = new UsefulRubrics
                {
                    RubricsId = usefulRubrics.RubricsId,
                    RubName = usefulRubrics.RubName,
                    RubNameEu = usefulRubrics.RubNameEu,
                    Picture = usefulRubrics.Picture
                };

                db.UsefulRubricses.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { usefulRubrics }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UsefulRubricses_Destroy([DataSourceRequest]DataSourceRequest request, UsefulRubrics usefulRubrics)
        {
            if (ModelState.IsValid)
            {
                var entity = new UsefulRubrics
                {
                    RubricsId = usefulRubrics.RubricsId,
                    RubName = usefulRubrics.RubName,
                    RubNameEu = usefulRubrics.RubNameEu,
                    Picture = usefulRubrics.Picture
                };

                db.UsefulRubricses.Attach(entity);
                db.UsefulRubricses.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { usefulRubrics }.ToDataSourceResult(request, ModelState));
        }


        public ActionResult Useful_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Useful> queryable = db.Usefuls;
            DataSourceResult result = queryable.ToDataSourceResult(request, useful => new
            {
                UsefulId = useful.UsefulId,
                Logo = useful.Logo,
                Title = useful.Title,
                Phone1 = useful.Phone1,
                DateAdd = useful.DateAdd,
                City = useful.City,
                Email = useful.Email,
                UsefulRubrics = useful.UsefulRubrics.RubName
            });
            return Json(result);
        }

        public ActionResult EditUseful(int id)
        {
            var model = db.Usefuls.FirstOrDefault(x => x.UsefulId == id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("UsefulList");
        }

        [HttpPost]
        public ActionResult SaveNew(string bodyContentUA, string bodyContentEN, string fileNameBLogo, string mainName, string mainNameEn, string address,
    string addressEn, string phone1, string phone2, string phone3, string email, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,
    int category, string videoUrl, string city, string cityEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            using (Context db = new Context())
            {
                var cat = db.UsefulRubricses.FirstOrDefault(x => x.RubricsId == category);
                db.Usefuls.Add(new Useful
                {
                    Address = address,
                    AddressEn = addressEn,
                    City = city,
                    CityEn = cityEn,
                    DateAdd = DateTime.Now,
                    Description = htmlProvider.Export(document),
                    DescriptionEn = htmlProvider.Export(documentEn),
                    Email = email,
                    Fb = fbUrl,
                    Inst = instUrl,
                    Google = googleUrl,
                    Title = mainName,
                    TitleEu = mainNameEn,
                    Phone1 = phone1,
                    Phone2 = phone2,
                    Phone3 = phone3,
                    Site = siteUrl,
                    Map = mapUrl,
                    Tw = twUrl,
                    Video = videoUrl,
                    Logo = fileNameBLogo,
                    UsefulRubrics = cat
                });
                db.SaveChanges();
            }
            return null;
        }

        public ActionResult Save(int id, string bodyContentUA, string bodyContentEN, string fileNameBLogo, string mainName, string mainNameEn, string address,
     string addressEn, string phone1, string phone2, string phone3, string email, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,
     int category, string videoUrl, string city, string cityEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            var curBuisnes = db.Usefuls.FirstOrDefault(x => x.UsefulId == id);
            if (curBuisnes != null)
            {
                var cat = db.UsefulRubricses.FirstOrDefault(x => x.RubricsId == category);
                curBuisnes.Address = address;
                curBuisnes.AddressEn = addressEn;
                curBuisnes.City = city;
                curBuisnes.CityEn = cityEn;
                curBuisnes.Description = htmlProvider.Export(document);
                curBuisnes.DescriptionEn = htmlProvider.Export(documentEn);
                curBuisnes.Email = email;
                curBuisnes.Fb = fbUrl;
                curBuisnes.Inst = instUrl;
                curBuisnes.Google = googleUrl;
                curBuisnes.Title = mainName;
                curBuisnes.TitleEu = mainNameEn;
                curBuisnes.Phone1 = phone1;
                curBuisnes.Phone2 = phone2;
                curBuisnes.Phone3 = phone3;
                curBuisnes.Site = siteUrl;
                curBuisnes.Map = mapUrl;
                curBuisnes.Tw = twUrl;
                curBuisnes.Video = videoUrl;
                curBuisnes.Logo = fileNameBLogo;
                curBuisnes.UsefulRubrics = cat;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var toDelete = db.Usefuls.FirstOrDefault(x => x.UsefulId == id);
            if (toDelete != null)
            {
                db.Usefuls.Remove(toDelete);
                db.SaveChanges();
            }

            return null;
        }

        public ActionResult GetUsefulList()
        {
            List<CategoryList> model = new List<CategoryList>();
            var data = db.UsefulRubricses;
            foreach (var x in data)
            {
                model.Add(new CategoryList
                {
                    CategoryId = x.RubricsId,
                    CategoryName = x.RubName
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

}
