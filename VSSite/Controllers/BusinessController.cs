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
    public class BusinessController : Controller
    {
        Context db = new Context();
        // GET: Business
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Хелперы
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexHelpers()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return View();
        }

        public ActionResult AddNewHelpers()
        {
            return View();
        }

        public ActionResult Busnesses_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Business> queryable = db.Businesses;
            DataSourceResult result = queryable.ToDataSourceResult(request, business => new
            {
                BusinessId = business.BusinessId,
                Logo = business.Logo,
                MainName = business.MainName,
                Email = business.Email,
                City = business.City,
                Phone1 = business.Phone1,
                DateAdd = business.DateAdd
            });

            return Json(result);
        }

        public ActionResult BusnessesHelper_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<BusinessHelpers> queryable = db.BusinessHelperses;
            DataSourceResult result = queryable.ToDataSourceResult(request, business => new
            {
                BusinessHelperslId = business.BusinessHelperslId,
                Logo = business.Logo,
                Title = business.Title,
                Email = business.Email,
                City = business.City,
                Phone1 = business.Phone1,
                DateAdd = business.DateAdd
            });

            return Json(result);
        }

        public ActionResult HierarchyBinding_Branch(int buiId, [DataSourceRequest] DataSourceRequest request)
        {
            var data = db.Branches.Where(x => x.Business.BusinessId == buiId).ToList();

            List<HierarchyModelBuisnes> model = new List<HierarchyModelBuisnes>();

            foreach (var x in data)
            {
                model.Add(new HierarchyModelBuisnes
                {
                    BLogo = x.Logo,
                    BMainName = x.MainName,
                    BPhone1 = x.Phone1,
                    BEmail = x.Email,
                    BCity = x.City,
                    BDateAdd = x.DateAdd
                    
                });
            }

            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {

                var model = db.Businesses.FirstOrDefault(x => x.BusinessId == id);
                if (model != null)
                {
                    return View(model);
                }
            return RedirectToAction("Index");

        }

        public ActionResult EditHelper(int id)
        {

            var model = db.BusinessHelperses.FirstOrDefault(x => x.BusinessHelperslId == id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("IndexHelpers");

        }

        public ActionResult Save(int id, string bodyContentUA, string bodyContentEN, string fileNameBLogo, string fileNamePhoto, string mainName, string mainNameEn, string address,
            string addressEn, string phone1, string phone2, string phone3, string email, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,
            int category, string videoUrl, string city, string cityEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            var curBuisnes = db.Businesses.FirstOrDefault(x => x.BusinessId == id);
            if (curBuisnes != null)
            {
                var cat = db.CategoryBusnesses.FirstOrDefault(x => x.IdCategory == category);
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
                curBuisnes.MainName = mainName;
                curBuisnes.MainNameEn = mainNameEn;
                curBuisnes.Phone1 = phone1;
                curBuisnes.Phone2 = phone2;
                curBuisnes.Phone3 = phone3;
                curBuisnes.Site = siteUrl;
                curBuisnes.Map = mapUrl;
                curBuisnes.Tw = twUrl;
                curBuisnes.Video = videoUrl;
                curBuisnes.Logo = fileNameBLogo;
                curBuisnes.Photo = fileNamePhoto;
                curBuisnes.Category = cat;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult SaveHelpers(int id, string bodyContentUA, string bodyContentEN, string fileNameBLogo, string mainName, string mainNameEn, string address,
    string addressEn, string phone1, string phone2, string phone3, string email, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,string city, string cityEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            var curBuisnes = db.BusinessHelperses.FirstOrDefault(x => x.BusinessHelperslId == id);
            if (curBuisnes != null)
            {
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
                curBuisnes.Logo = fileNameBLogo;

                db.SaveChanges();
            }

            return RedirectToAction("IndexHelpers");
        }

        [HttpPost]
        public ActionResult SaveNew(string bodyContentUA,string bodyContentEN, string fileNameBLogo, string fileNamePhoto, string mainName, string mainNameEn, string address,
            string addressEn, string phone1,  string phone2, string phone3, string email, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,
            int category, string videoUrl, string city, string cityEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            using (Context db = new Context())
            {
                var cat = db.CategoryBusnesses.FirstOrDefault(x => x.IdCategory == category);
                db.Businesses.Add(new Business
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
                    Video = videoUrl,
                    Logo = fileNameBLogo,
                    Photo = fileNamePhoto,
                    Category = cat
                });
                db.SaveChanges();
            }
            return null;
        }

        [HttpPost]
        public ActionResult SaveNewHelpers(string bodyContentUA, string bodyContentEN, string fileNameBLogo, string fileNamePhoto, string mainName, string mainNameEn, string address,
    string addressEn, string phone1, string phone2, string phone3, string email, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl, string city, string cityEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            using (Context db = new Context())
            {
                db.BusinessHelperses.Add(new BusinessHelpers
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
                    Logo = fileNameBLogo,
                });
                db.SaveChanges();
            }
            return null;
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (Context context = new Context())
            {
                var curBuisnes = context.Businesses.FirstOrDefault(x => x.BusinessId == id);
                if (curBuisnes !=null)
                {
                    var curBuisnesBr = curBuisnes.Branches;
                    if (curBuisnesBr.Count >0)
                    {
                        context.Branches.RemoveRange(curBuisnesBr);
                    }
                    context.Businesses.Remove(curBuisnes);
                    context.SaveChanges();
                }
            }

            return null;
        }

        [HttpPost]
        public ActionResult DeleteHelpers(int id)
        {
            using (Context context = new Context())
            {
                var curBuisnes = context.BusinessHelperses.FirstOrDefault(x => x.BusinessHelperslId == id);
                if (curBuisnes != null)
                {
                    context.BusinessHelperses.Remove(curBuisnes);
                    context.SaveChanges();
                }
            }

            return null;
        }

        public ActionResult Async_Save(IEnumerable<HttpPostedFileBase> logoUpload)
        {
            var name = Guid.NewGuid().ToString();
            string fullFile = "";
            foreach (var file in logoUpload)
            {

                if (file != null)
                {
                    //var fileName = Path.GetFileName(file.FileName);

                    var ext = Path.GetExtension(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Logo"), $"{name}{ext}");
                    fullFile = $"{name}{ext}";
                    file.SaveAs(physicalPath);
                }
            }

            return Json(new { fileName = fullFile });
        }

        public ActionResult Async_Save2(IEnumerable<HttpPostedFileBase> photoUpload)
        {
            var name = Guid.NewGuid().ToString();
            string fullFile = "";
            foreach (var file in photoUpload)
            {

                if (file != null)
                {
                    //var fileName = Path.GetFileName(file.FileName);

                    var ext = Path.GetExtension(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Photo"), $"{name}{ext}");
                    fullFile = $"{name}{ext}";
                    file.SaveAs(physicalPath);
                }
            }

            return Json(new { fileName = fullFile });
        }

        public ActionResult Async_Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Logo"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult Async_Remove2(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Photo"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }
    }

    public class HierarchyModelBuisnes
    {
        public string BLogo { get; set; }
        public string BMainName { get; set; }
        public string BEmail { get; set; }
        public string BCity { get; set; }
        public string BPhone1 { get; set; }
        public DateTime BDateAdd { get; set; }
    }
}