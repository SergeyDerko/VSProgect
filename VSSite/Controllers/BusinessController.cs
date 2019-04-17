using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.Model;
using VSCore.Concrete;
using VSCore.Entity;

namespace VSSite.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult Index()
        {
            return null;
        }

        public ActionResult AddNew()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return null;
        }

        [HttpPost]
        public ActionResult SaveEdit(string bodyContentUA,string bodyContentEN, string fileNameBLogo, string fileNamePhoto, string mainName, string mainNameEn, string address,
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


        public ActionResult Delete(int id)
        {
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
}