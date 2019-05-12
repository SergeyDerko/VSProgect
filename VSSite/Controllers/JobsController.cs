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
    public class JobsController : Controller
    {
        Context db = new Context();
        // GET: Jobs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return View();

        }

        public ActionResult Jobs_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Jobs> queryable = db.Jobses;
            DataSourceResult result = queryable.ToDataSourceResult(request, jobs => new
            {
                JobsId = jobs.JobsId,
                LogoJobs = jobs.LogoJobs,
                TitleJobs = jobs.TitleJobs,
                EmailJobs = jobs.EmailJobs,
                City = jobs.City,
                Phone1 = jobs.Phone1,
                DateAdd = jobs.DateAdd,
                Description = jobs.DescriptionJobs,
                Site = jobs.Site,
                Address = jobs.Address,
                Google = jobs.Google,
                Tw = jobs.Tw,
                Inst = jobs.Inst,
                Fb = jobs.Fb
            });

            return Json(result);
        }


        public ActionResult Save(int id, string bodyContentUA, string bodyContentEN, string fileNameBLogo, string address,
            string addressEn, string phone1, string phone2, string phone3, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,
            string city, string cityEn, string name, string nameEn,string email)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            var curJob = db.Jobses.FirstOrDefault(x => x.JobsId == id);
            if (curJob != null)
            {
                curJob.Address = address;
                curJob.AddressEn = addressEn;
                curJob.City = city;
                curJob.TitleJobs = name;
                curJob.TitleEuJobs = nameEn;
                curJob.CityEn = cityEn;
                curJob.DescriptionJobs = htmlProvider.Export(document);
                curJob.DescriptionJobs = htmlProvider.Export(documentEn);
                curJob.Fb = fbUrl;
                curJob.Inst = instUrl;
                curJob.Google = googleUrl;
                curJob.Phone1 = phone1;
                curJob.Phone2 = phone2;
                curJob.Phone3 = phone3;
                curJob.Site = siteUrl;
                curJob.Map = mapUrl;
                curJob.Tw = twUrl;
                curJob.LogoJobs = fileNameBLogo;
                curJob.EmailJobs = email;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveNew(string bodyContentUA, string bodyContentEN, string fileNameBLogo, string address,
            string addressEn, string phone1, string phone2, string phone3, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,
            string city, string cityEn, string name, string nameEn, string email)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            using (Context db = new Context())
            {
                db.Jobses.Add(new Jobs
                {
                    Address = address,
                    AddressEn = addressEn,
                    City = city,
                    CityEn = cityEn,
                    DateAdd = DateTime.Now,
                    DescriptionJobs = htmlProvider.Export(document),
                    DescriptionEnJobs = htmlProvider.Export(documentEn),
                    Fb = fbUrl,
                    Inst = instUrl,
                    Google = googleUrl,
                    Phone1 = phone1,
                    Phone2 = phone2,
                    Phone3 = phone3,
                    Site = siteUrl,
                    Map = mapUrl,
                    Tw = twUrl,
                    LogoJobs = fileNameBLogo,
                    TitleJobs = name,
                    TitleEuJobs = nameEn,
                    EmailJobs = email
                });
                db.SaveChanges();
            }
            return null;
        }

        public ActionResult Edit(int id)
        {
            var model = db.Jobses.FirstOrDefault(x => x.JobsId == id);
            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (Context db = new Context())
            {
                var data = db.Jobses.FirstOrDefault(x => x.JobsId == id);
                if (data != null)
                {
                    db.Jobses.Remove(data);
                    db.SaveChanges();
                }
            }

            return null;
        }

    }
}