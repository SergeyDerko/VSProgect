using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VSCore.Concrete;

namespace VSSite.Controllers
{
    public class PlacementController : Controller
    {
        Context db = new Context();
        // GET: Placement
        public ActionResult Index()
        {
            var model = db.PlacementOnSites.OrderByDescending(x=>x.Date).ToList();

            return View(model);
        }
    }
}