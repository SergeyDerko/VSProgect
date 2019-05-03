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
    public class TeamMemberController : Controller
    {
        Context context = new Context();
        // GET: TeamMember
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TeamMember_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<TeamMember> queryable = context.TeamMembers;
            DataSourceResult result = queryable.ToDataSourceResult(request, team => new
            {
                Id = team.Id,
                Photo = team.Photo,
                Name = team.Name,
                Email = team.Email,
                City = team.City,
                Phone1 = team.Phone1,
            });

            return Json(result);
        }

        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveEdit(int id, string bodyContentUA, string bodyContentEN, string fileNamePhoto, string mainName, string mainNameEn,
            string phone1, string phone2, string phone3, string email, string fbUrl, string googleUrl, string twUrl, string instUrl, string city, string cityEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            var curMamber = context.TeamMembers.FirstOrDefault(x => x.Id == id);
            if (curMamber != null)
            {
                curMamber.City = city;
                curMamber.CityEn = cityEn;
                curMamber.Description = htmlProvider.Export(document);
                curMamber.DescriptionEn = htmlProvider.Export(documentEn);
                curMamber.Email = email;
                curMamber.Fb = fbUrl;
                curMamber.Inst = instUrl;
                curMamber.Google = googleUrl;
                curMamber.Name = mainName;
                curMamber.NameEn = mainNameEn;
                curMamber.Phone1 = phone1;
                curMamber.Phone2 = phone2;
                curMamber.Phone3 = phone3;
                curMamber.Tw = twUrl;
                curMamber.Photo = fileNamePhoto;

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveNew(string bodyContentUA, string bodyContentEN, string fileNamePhoto, string mainName, string mainNameEn,
            string phone1, string phone2, string phone3, string email, string fbUrl, string googleUrl, string twUrl, string instUrl, string city, string cityEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            using (Context db = new Context())
            {
                db.TeamMembers.Add(new TeamMember
                {

                    City = city,
                    CityEn = cityEn,
                    Description = htmlProvider.Export(document),
                    DescriptionEn = htmlProvider.Export(documentEn),
                    Email = email,
                    Fb = fbUrl,
                    Inst = instUrl,
                    Google = googleUrl,
                    Name = mainName,
                    NameEn = mainNameEn,
                    Phone1 = phone1,
                    Phone2 = phone2,
                    Phone3 = phone3,
                    Tw = twUrl,
                    Photo = fileNamePhoto,
                });
                db.SaveChanges();
            }
            return null;
        }

        public ActionResult Edit(int id)
        {
            var model = context.TeamMembers.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (Context db = new Context())
            {
                var curmMenber = db.TeamMembers.FirstOrDefault(x => x.Id == id);
                if (curmMenber != null)
                {
                    db.TeamMembers.Remove(curmMenber);
                    db.SaveChanges();
                }
            }
            return null;
        }

        public ActionResult Async_Save(IEnumerable<HttpPostedFileBase> photoUpload)
        {
            var name = Guid.NewGuid().ToString();
            string fullFile = "";
            foreach (var file in photoUpload)
            {

                if (file != null)
                {
                    //var fileName = Path.GetFileName(file.FileName);

                    var ext = Path.GetExtension(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Team"), $"{name}{ext}");
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
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Team"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("OK");
        }
    }
}