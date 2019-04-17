﻿﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
 using System.IO;
 using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
 using VSCore.Concrete;
 using VSCore.Entity;

namespace VSSite.Controllers
{
    public class CategoryController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryBusnesses_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<CategoryBusness> categorybusnesses = db.CategoryBusnesses;
            DataSourceResult result = categorybusnesses.ToDataSourceResult(request, categoryBusness => new {
                IdCategory = categoryBusness.IdCategory,
                Logo = categoryBusness.Logo,
                Name = categoryBusness.Name,
                NameEn = categoryBusness.NameEn,
                Meta1 = categoryBusness.Meta1,
                Meta2 = categoryBusness.Meta2,
                Meta3 = categoryBusness.Meta3
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CategoryBusnesses_Create([DataSourceRequest]DataSourceRequest request, CategoryBusness categoryBusness)
        {
            if (ModelState.IsValid)
            {
                var entity = new CategoryBusness
                {
                    Logo = categoryBusness.Logo,
                    Name = categoryBusness.Name,
                    NameEn = categoryBusness.NameEn,
                    Meta1 = categoryBusness.Meta1,
                    Meta2 = categoryBusness.Meta2,
                    Meta3 = categoryBusness.Meta3
                };

                db.CategoryBusnesses.Add(entity);
                db.SaveChanges();
                categoryBusness.IdCategory = entity.IdCategory;
            }

            return Json(new[] { categoryBusness }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CategoryBusnesses_Update([DataSourceRequest]DataSourceRequest request, CategoryBusness categoryBusness)
        {
            if (ModelState.IsValid)
            {
                var entity = new CategoryBusness
                {
                    IdCategory = categoryBusness.IdCategory,
                    Logo = categoryBusness.Logo,
                    Name = categoryBusness.Name,
                    NameEn = categoryBusness.NameEn,
                    Meta1 = categoryBusness.Meta1,
                    Meta2 = categoryBusness.Meta2,
                    Meta3 = categoryBusness.Meta3
                };

                db.CategoryBusnesses.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { categoryBusness }.ToDataSourceResult(request, ModelState));
        }


        public ActionResult Async_Save(IEnumerable<HttpPostedFileBase> files)
        {
            var name = Guid.NewGuid().ToString();
            string fullFile = "";
            foreach (var file in files)
            {

                if (file != null)
                {
                    //var fileName = Path.GetFileName(file.FileName);

                    var ext = Path.GetExtension(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Category"), $"{name}{ext}");
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
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Category"), fileName);

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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
