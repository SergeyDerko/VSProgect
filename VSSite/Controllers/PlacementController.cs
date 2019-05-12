using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VSCore.Concrete;

namespace VSSite.Controllers
{
    [Authorize]
    public class PlacementController : Controller
    {
        Context db = new Context();
        // GET: Placement
        public ActionResult Index()
        {
            var model = db.PlacementOnSites.OrderByDescending(x=>x.Date).ToList();

            return View(model);
        }


        public ActionResult Delete(int id)
        {
            using (Context context = new Context())
            {
                var toRemove = context.PlacementOnSites.FirstOrDefault(x => x.Id == id);
                if (toRemove != null)
                {
                    context.PlacementOnSites.Remove(toRemove);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}