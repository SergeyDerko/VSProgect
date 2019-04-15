using System.Linq;
using System.Web.Mvc;
using VSCore.Concrete;
using VSCore.Entity;

namespace VSSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string DataSid()
        {
            using (Context context = new Context())
            {
                if (!context.Businesses.Any())
                {
                    #region Категории бизнессов

                    context.CategoryBusnesses.Add(new CategoryBusness
                    {
                        Name = "IT категория",
                        NameEn = "IT Category"
                    });
                    context.CategoryBusnesses.Add(new CategoryBusness
                    {
                        Name = "Еда",
                        NameEn = "Food"
                    });
                    context.CategoryBusnesses.Add(new CategoryBusness
                    {
                        Name = "Услуги",
                        NameEn = "Services"
                    });

                    context.SaveChanges();

                    #endregion

                    #region Бизнессы

                    context.Businesses.Add(new Business
                    {
                        
                    });
                    #endregion



                    #region Новости

                    context.Newses.Add(new News
                    {
                        
                    });



                    #endregion

                    #region Партнерка

                    context.Partners.Add(new Partner
                    {
                        
                    });


                    #endregion

                    #region Рубрики полезно

                    context.UsefulRubricses.Add(new UsefulRubrics
                    {

                    });


                    #endregion



                }
            }

            return "Гтово!";
        }
    }
}