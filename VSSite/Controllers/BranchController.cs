using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
    
    public class BranchController : Controller
    {
        Context db = new Context();
        // GET: Branch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(int id, string bodyContentUA, string bodyContentEN, string fileNameBLogo, string fileNamePhoto, string mainName, string mainNameEn, string address,
    string addressEn, string phone1, string phone2, string phone3, string email, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,
    int buisnes, string city, string cityEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            var curBranch = db.Branches.FirstOrDefault(x => x.BranchId == id);
            if (curBranch != null)
            {
                var bui = db.Businesses.FirstOrDefault(x => x.BusinessId == buisnes);
                curBranch.Address = address;
                curBranch.AddressEn = addressEn;
                curBranch.City = city;
                curBranch.CityEn = cityEn;
                curBranch.Description = htmlProvider.Export(document);
                curBranch.DescriptionEn = htmlProvider.Export(documentEn);
                curBranch.Email = email;
                curBranch.Fb = fbUrl;
                curBranch.Inst = instUrl;
                curBranch.Google = googleUrl;
                curBranch.MainName = mainName;
                curBranch.MainNameEn = mainNameEn;
                curBranch.Phone1 = phone1;
                curBranch.Phone2 = phone2;
                curBranch.Phone3 = phone3;
                curBranch.Site = siteUrl;
                curBranch.Map = mapUrl;
                curBranch.Tw = twUrl;
                curBranch.Logo = fileNameBLogo;
                curBranch.Photo = fileNamePhoto;
                curBranch.Business = bui;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult SaveNew(string bodyContentUA, string bodyContentEN, string fileNameBLogo, string fileNamePhoto, string mainName, string mainNameEn, string address,
    string addressEn, string phone1, string phone2, string phone3, string email, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,
    int category, string city, string cityEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            using (Context db = new Context())
            {
                var cat = db.Businesses.FirstOrDefault(x => x.BusinessId == category);
                db.Branches.Add(new Branch
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
                    MainName = mainName,
                    MainNameEn = mainNameEn,
                    Phone1 = phone1,
                    Phone2 = phone2,
                    Phone3 = phone3,
                    Site = siteUrl,
                    Map = mapUrl,
                    Tw = twUrl,
                    Logo = fileNameBLogo,
                    Photo = fileNamePhoto,
                    Business = cat
                });
                db.SaveChanges();
            }
            return null;
        }

        public ActionResult Edit(int id)
        {
            var model = db.Branches.FirstOrDefault(x => x.BranchId == id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (Context context = new Context())
            {
                var curbranch = context.Branches.FirstOrDefault(x => x.BranchId == id);
                if (curbranch != null)
                {
                    context.Branches.Remove(curbranch);
                    context.SaveChanges();
                }
            }
            return null;
        }

        public ActionResult Branches_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Branch> queryable = db.Branches;
            DataSourceResult result = queryable.ToDataSourceResult(request, business => new
            {
                BranchId = business.BranchId,
                Logo = business.Logo,
                MainName = business.MainName,
                Email = business.Email,
                City = business.City,
                Phone1 = business.Phone1,
                DateAdd = business.DateAdd
            });

            return Json(result);
        }

        public ActionResult GetBuisnesList()
        {
            List<BuisnesList> model = new List<BuisnesList>();
            var data = db.Businesses;
            foreach (var x in data)
            {
                model.Add(new BuisnesList
                {
                    BuisnesName = x.MainName,
                    BuisnesId = x.BusinessId
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }

    public class BuisnesList
    {
        public string BuisnesName { get; set; }
        public int BuisnesId { get; set; }
    }
}