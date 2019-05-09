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
    public class PartnerController : Controller
    {
        Context db = new Context();
        // GET: Partner
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Partners_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Partner> queryable = db.Partners;
            DataSourceResult result = queryable.ToDataSourceResult(request, partner => new
            {
                PartnerId = partner.PartnerId,
                Logo = partner.Logo,
                Name = partner.Name,
                City = partner.City,
                Phone1 = partner.Phone1,
                DateAdd = partner.DateAdd,
                Description = partner.Description,
                Site = partner.Site,
                Address = partner.Address,
                Google = partner.Google,
                Tw = partner.Tw,
                Inst = partner.Inst,
                Fb = partner.Fb

            });

            return Json(result);
        }

        public ActionResult AddNew()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {

            var model = db.Partners.FirstOrDefault(x => x.PartnerId == id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }

        public ActionResult Save(int id, string bodyContentUA, string bodyContentEN, string fileNameBLogo, string address,
    string addressEn, string phone1, string phone2, string phone3, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,
    string city, string cityEn, string name, string nameEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            var curPartner = db.Partners.FirstOrDefault(x => x.PartnerId == id);
            if (curPartner != null)
            {
                curPartner.Address = address;
                curPartner.AddressEn = addressEn;
                curPartner.City = city;
                curPartner.Name = name;
                curPartner.NameEn = nameEn;
                curPartner.CityEn = cityEn;
                curPartner.Description = htmlProvider.Export(document);
                curPartner.DescriptionEn = htmlProvider.Export(documentEn);
                curPartner.Fb = fbUrl;
                curPartner.Inst = instUrl;
                curPartner.Google = googleUrl;
                curPartner.Phone1 = phone1;
                curPartner.Phone2 = phone2;
                curPartner.Phone3 = phone3;
                curPartner.Site = siteUrl;
                curPartner.Map = mapUrl;
                curPartner.Tw = twUrl;
                curPartner.Logo = fileNameBLogo;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveNew(string bodyContentUA, string bodyContentEN, string fileNameBLogo, string address,
            string addressEn, string phone1, string phone2, string phone3, string siteUrl, string fbUrl, string googleUrl, string twUrl, string instUrl, string mapUrl,
            string city, string cityEn, string name, string nameEn)
        {
            string bodyHtml = HttpUtility.HtmlDecode(bodyContentUA);
            string bodyHtmlEn = HttpUtility.HtmlDecode(bodyContentEN);
            HtmlFormatProvider htmlProvider = new HtmlFormatProvider();
            RadFlowDocument document = htmlProvider.Import(bodyHtml);
            RadFlowDocument documentEn = htmlProvider.Import(bodyHtmlEn);
            using (Context db = new Context())
            {
                db.Partners.Add(new Partner
                {
                    Address = address,
                    AddressEn = addressEn,
                    City = city,
                    CityEn = cityEn,
                    DateAdd = DateTime.Now,
                    Description = htmlProvider.Export(document),
                    DescriptionEn = htmlProvider.Export(documentEn),
                    Fb = fbUrl,
                    Inst = instUrl,
                    Google = googleUrl,
                    Phone1 = phone1,
                    Phone2 = phone2,
                    Phone3 = phone3,
                    Site = siteUrl,
                    Map = mapUrl,
                    Tw = twUrl,
                    Logo = fileNameBLogo,
                    Name = name,
                    NameEn = nameEn
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
                var curPartner = context.Partners.FirstOrDefault(x => x.PartnerId == id);
                if (curPartner != null)
                {
                    context.Partners.Remove(curPartner);
                    context.SaveChanges();
                }
            }
            return null;
        }

    }
}