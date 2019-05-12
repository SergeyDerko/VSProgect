using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace VSSite.Controllers
{
    [Authorize]
    public class ImageBrowserController : EditorImageBrowserController
    {
        private const string ContentFolderRoot = "~/Content/";
        private const string PrettyName = "Images/";
        private static readonly string[] FoldersToCopy = new[] { "~/Content/shared/" };

        public override string ContentPath => CreateUserFolder();

        /// <summary>
        /// Создание дериктории
        /// </summary>
        /// <returns></returns>
        private string CreateUserFolder()
        {
            var virtualPath = Path.Combine(ContentFolderRoot, "MailTemplateImage", PrettyName);
            var path = Server.MapPath(virtualPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                foreach (var sourceFolder in FoldersToCopy)
                {
                    CopyFolder(Server.MapPath(sourceFolder), path);
                }
            }
            return virtualPath;
        }

        /// <summary>
        /// Копирование дерикторий
        /// </summary>
        /// <param name="source">Временная</param>
        /// <param name="destination">Постоянная</param>
        private void CopyFolder(string source, string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            foreach (var file in Directory.EnumerateFiles(source))
            {
                if (file != null)
                {
                    var dest = Path.Combine(destination, Path.GetFileName(file));
                    System.IO.File.Copy(file, dest);
                }
            }
            foreach (var folder in Directory.EnumerateDirectories(source))
            {
                if (folder != null)
                {
                    var dest = Path.Combine(destination, Path.GetFileName(folder));
                    CopyFolder(folder, dest);
                }
            }
        }
    }
}