using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VSSite.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        public async Task<JsonResult> UploadFile(string id)
        {
            string fullFile = "";
            try
            {
                var name = Guid.NewGuid().ToString();

                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        // get a stream
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        var ext = Path.GetExtension(file);
                        if (id == "p")
                        {
                            var path = Path.Combine(Server.MapPath("~/Images/Photo"), $"{name}{ext}");
                            using (var fileStream = System.IO.File.Create(path))
                            {
                                stream.CopyTo(fileStream);
                            }
                        }
                        if (id == "l")
                        {
                            var path = Path.Combine(Server.MapPath("~/Images/Logo"), $"{name}{ext}");
                            using (var fileStream = System.IO.File.Create(path))
                            {
                                stream.CopyTo(fileStream);
                            }
                        }
                        if (id == "t")
                        {
                            var path = Path.Combine(Server.MapPath("~/Images/Team"), $"{name}{ext}");
                            using (var fileStream = System.IO.File.Create(path))
                            {
                                stream.CopyTo(fileStream);
                            }
                        }
                        if (id == "c")
                        {
                            var path = Path.Combine(Server.MapPath("~/Images/Category"), $"{name}{ext}");
                            using (var fileStream = System.IO.File.Create(path))
                            {
                                stream.CopyTo(fileStream);
                            }
                        }
                        if (id == "n")
                        {
                            var path = Path.Combine(Server.MapPath("~/Images/"), $"{name}{ext}");
                            using (var fileStream = System.IO.File.Create(path))
                            {
                                stream.CopyTo(fileStream);
                            }
                        }

                        fullFile = $"{name}{ext}";
                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }

            return Json(fullFile);
        }

        [HttpPost]
        public async Task<JsonResult> RemoveFile(string fileName, string type)
        {

            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(type))
            {
                if (type == "p")
                {
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Photo"), fileName);
                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                    else
                    {
                        return Json("Faild");
                    }
                }
                if (type == "l")
                {
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Logo"), fileName);
                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                    else
                    {
                        return Json("Faild");
                    }
                }
                if (type == "t")
                {
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Team"), fileName);
                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                    else
                    {
                        return Json("Faild");
                    }
                }
                if (type == "c")
                {
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/Category"), fileName);
                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                    else
                    {
                        return Json("Faild");
                    }
                }
                if (type == "n")
                {
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                    else
                    {
                        return Json("Faild");
                    }
                }
            }
            else
            {
                return Json("Invalid");
            }
            return Json($"OK_{type}");
        }
    }
}