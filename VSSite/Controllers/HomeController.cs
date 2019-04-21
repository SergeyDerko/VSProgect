using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Telerik.Windows.Documents.Flow.Model.Lists;
using VSCore.Concrete;
using VSCore.Entity;
using VSSite.Models.ForViews;

namespace VSSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Выдача всех бизнессов
        /// </summary>
        /// <returns></returns>
        public ActionResult Business()
        {
            Context context = new Context();
            BusinessPageModel model = new BusinessPageModel();
          
            List<string>list = new List<string>();
            if (Resources.Translator.language == "ru")
            {
                foreach (var i in context.Businesses.GroupBy(x => x.City))
                  list.Add(i.Key);
                model.Category = context.CategoryBusnesses.ToList();
            }
            else
            {
                foreach (var i in context.Businesses.GroupBy(x => x.CityEn))
                    list.Add(i.Key);
                model.Category = context.CategoryBusnesses.ToList();
            }
            model.Sity = list;
            return View(model);
        }


        /// <summary>
        /// Сортировка бизнессов
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BusinessSort(int page,string sity, int category)
        {

            Context context = new Context();
            var tempBuis = context.Businesses.ToList();
            #region Сортировки

            if (!string.IsNullOrEmpty(sity) && sity != "oll")
                tempBuis = Resources.Translator.language == "ru" ? tempBuis.Where(x => x.City == sity).ToList() : tempBuis.Where(x => x.CityEn == sity).ToList();
            if (category != 0)
                tempBuis = tempBuis.Where(x => x.Category.IdCategory == category).ToList();
            #endregion
            IEnumerable<Business> businesses = tempBuis.OrderByDescending(x=>x.DateAdd).Skip((page - 1) * 10).Take(10);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = 10, TotalItems = tempBuis.Count };
            BusinessPageModel model = new BusinessPageModel{Businesses = businesses.ToList(),PageInfo = pageInfo };
            return PartialView("PartialBusiness",model);
        }

        /// <summary>
        /// Выдача партнеров
        /// </summary>
        /// <returns></returns>
        public ActionResult Partners()
        {
           
            return View();
        }

        /// <summary>
        /// Выдача партнеров с сортировками
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PartnersSort(int page)
        {
            Context context = new Context();
            var temp = context.Partners.ToList();
            IEnumerable<Partner> businesses = temp.OrderByDescending(x => x.DateAdd).Skip((page - 1) * 5).Take(5);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = 5, TotalItems = temp.Count };
            PartnersPageModel model = new PartnersPageModel { Partners = businesses.ToList(), PageInfo = pageInfo };
            return PartialView("PartialPartners", model);
        }

        /// <summary>
        /// Выдача вакансий
        /// </summary>
        /// <returns></returns>
        public ActionResult Jobs()
        {
            return View();
        }

        /// <summary>
        /// Выдача вакансий с сортировками
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult JobsSort(int page)
        {
            Context context = new Context();
            var temp = context.Jobses.ToList();
            IEnumerable<Jobs> jobs = temp.OrderByDescending(x => x.DateAdd).Skip((page - 1) * 5).Take(5);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = 5, TotalItems = temp.Count };
            JobsHelpersPageModel model = new JobsHelpersPageModel { Jobses = jobs.ToList(), PageInfo = pageInfo };
            return PartialView("PartialJobs",model);
        }

        /// <summary>
        /// Выдача полезного
        /// </summary>
        /// <returns></returns>
        public ActionResult Useful()
        {
            return View();
        }

        /// <summary>
        /// Выдача полезного с сортировками
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UsefulSort(int page)
        {
            return View();
        }

        /// <summary>
        /// Выдача новостей
        /// </summary>
        /// <returns></returns>
        public ActionResult News()
        {
            return View();
        }

        /// <summary>
        /// Выдача новостей с сортировками
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewsSort(int page)
        {
            Context context = new Context();
            var temp = context.Newses.ToList();
            IEnumerable<News> news = temp.OrderByDescending(x => x.DateNews).Skip((page - 1) * 5).Take(5);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = 5, TotalItems = temp.Count };
            NewsPageModel model = new NewsPageModel { Newses = news.ToList(), PageInfo = pageInfo };
            return PartialView("PartialNews", model);
        }

        /// <summary>
        /// Выдача помощь бизнесу
        /// </summary>
        /// <returns></returns>
        public ActionResult Help()
        {
            return View();
        }

        /// <summary>
        /// Выдача помощь бизнесу с сортировками
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult HelpSort(int page)
        {
            return View();
        }

        /// <summary>
        /// Выдача про нас
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutAs()
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

                    for (int i = 0; i < 20; i++)
                    {
                        context.Businesses.Add(new Business
                        {
                            Description = "<span>Тестовая надпись все дела, Путин ХУйло, лалалалал лалал лала :)</span>",
                            DescriptionEn = "<span>Putin huilo lal al aala la la lol  :)</span>",
                            Address = "Ул.УбитогоСепара 666 кв 66",
                            AddressEn = "killSepar 666",
                            Category = context.CategoryBusnesses.FirstOrDefault(x => x.IdCategory == 1),
                            City = "Киев",
                            CityEn = "Kiev",
                            DateAdd = DateTime.Now,
                            Email = "milamamaramu@gmail.com",
                            Fb = "https://www.facebook.com/",
                            Google = "https://www.facebook.com/",
                            Inst = "https://www.facebook.com/",
                            Logo = "fsack.png",
                            MainName = "Название",
                            MainNameEn = "Name",
                            Map = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2539.228216895754!2d30.513098316050094!3d50.474094979478714!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40d4ce1141d71c09%3A0x868442c1d928bb3c!2z0LLRg9C70LjRhtGPINCi0YPRgNGW0LLRgdGM0LrQsCwgMzEsINCa0LjRl9CyLCDQo9C60YDQsNC40L3QsA!5e0!3m2!1sru!2sus!4v1490966426023",
                            Phone1 = "9999999999999",
                            Phone2 = "9999999999999",
                            Phone3 = "9999999999999",
                            Photo = "fsack.png",
                            Site = "https://www.facebook.com/",
                            Tw = "https://www.facebook.com/",
                            Video = "https://www.youtube.com/watch?v=1qDbi0_fAHg"
                        });
                    }

                    context.SaveChanges();
                    #endregion

                    #region отделения бизнесов

                    for (int i = 0; i < 2; i++)
                    {


                        context.Branches.Add(new Branch
                        {

                            Description = "<span>Тестовая надпись все дела, Путин ХУйло, лалалалал лалал лала :)</span>",
                            DescriptionEn = "<span>Putin huilo lal al aala la la lol  :)</span>",
                            Address = "Ул.УбитогоСепара 666 кв 66",
                            AddressEn = "killSepar 666",
                            Business = context.Businesses.FirstOrDefault(x => x.BusinessId == 1),
                            City = "Киев",
                            CityEn = "Kiev",
                            DateAdd = DateTime.Now,
                            Email = "milamamaramu@gmail.com",
                            Fb = "https://www.facebook.com/",
                            Google = "https://www.facebook.com/",
                            Inst = "https://www.facebook.com/",
                            Logo = "fsack.png",
                            MainName = "Название",
                            MainNameEn = "Name",
                            Map = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2539.228216895754!2d30.513098316050094!3d50.474094979478714!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40d4ce1141d71c09%3A0x868442c1d928bb3c!2z0LLRg9C70LjRhtGPINCi0YPRgNGW0LLRgdGM0LrQsCwgMzEsINCa0LjRl9CyLCDQo9C60YDQsNC40L3QsA!5e0!3m2!1sru!2sus!4v1490966426023",
                            Phone1 = "9999999999999",
                            Phone2 = "9999999999999",
                            Phone3 = "9999999999999",
                            Photo = "fsack.png",
                            Site = "https://www.facebook.com/",
                            Tw = "https://www.facebook.com/",

                        });
                    }

                    context.SaveChanges();

                    #endregion

                    #region Новости

                    for (int i = 0; i < 20; i++)
                    {
                        context.Newses.Add(new News
                        {
                            Video = "https://www.youtube.com/watch?v=1qDbi0_fAHg",
                            Body = "<span>Тестовая надпись все дела, Путин ХУйло, лалалалал лалал лала :)</span>",
                            BodyEn = "<span>Putin huilo lal al aala la la lol  :)</span>",
                            DateNews = DateTime.Now,
                            DetailUrl = "https://www.facebook.com/",
                            Picture = "fsack.png",
                            Title = "Новость",
                            TitleEn = "News"
                        });
                    }

                    context.SaveChanges();
                    #endregion

                    #region Партнерка

                    for (int i = 0; i < 20; i++)
                    {
                        context.Partners.Add(new Partner
                        {
                            Description = "<span>Тестовая надпись все дела, Путин ХУйло, лалалалал лалал лала :)</span>",
                            DescriptionEn = "<span>Putin huilo lal al aala la la lol  :)</span>",
                            NameEn = "Партнер",
                            Site = "https://www.facebook.com/",
                            Tw = "https://www.facebook.com/",
                            Inst = "https://www.facebook.com/",
                            Address = "Ул.УбитогоСепара 666 кв 66",
                            AddressEn = "killSepar 666",
                            Fb = "https://www.facebook.com/",
                            Map = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2539.228216895754!2d30.513098316050094!3d50.474094979478714!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40d4ce1141d71c09%3A0x868442c1d928bb3c!2z0LLRg9C70LjRhtGPINCi0YPRgNGW0LLRgdGM0LrQsCwgMzEsINCa0LjRl9CyLCDQo9C60YDQsNC40L3QsA!5e0!3m2!1sru!2sus!4v1490966426023",
                            Phone1 = "9999999999999",
                            Phone2 = "9999999999999",
                            Phone3 = "9999999999999",
                            Logo = "fsack.png",
                            City = "Киев",
                            CityEn = "Kiev",
                            DateAdd = DateTime.Now,
                            Google = "https://www.facebook.com/",
                            Name = "Partner",
                        });
                    }
                    context.SaveChanges();
                    #endregion

                    #region Рубрики полезно

                    context.UsefulRubricses.Add(new UsefulRubrics
                    {
                        Picture = "fsack.png",
                        RubName = "Рубрика1",
                        RubNameEu = "Rubric1"
                    });
                    context.UsefulRubricses.Add(new UsefulRubrics
                    {
                        Picture = "fsack.png",
                        RubName = "Рубрика2",
                        RubNameEu = "Rubric2"
                    });
                    context.UsefulRubricses.Add(new UsefulRubrics
                    {
                        Picture = "fsack.png",
                        RubName = "Рубрика3",
                        RubNameEu = "Rubric3"
                    });
                    context.UsefulRubricses.Add(new UsefulRubrics
                    {
                        Picture = "fsack.png",
                        RubName = "Рубрика4",
                        RubNameEu = "Rubric4"
                    });
                    context.SaveChanges();

                    #endregion

                    #region Полезно

                    for (int i = 0; i < 20; i++)
                    {

                        context.Usefuls.Add(new Useful
                        {
                            Description = "<span>Тестовая надпись все дела, Путин ХУйло, лалалалал лалал лала :)</span>",
                            DescriptionEn = "<span>Putin huilo lal al aala la la lol  :)</span>",
                            Address = "Ул.УбитогоСепара 666 кв 66",
                            AddressEn = "killSepar 666",
                            UsefulRubrics = context.UsefulRubricses.FirstOrDefault(x => x.RubricsId == 1),
                            City = "Киев",
                            CityEn = "Kiev",
                            DateAdd = DateTime.Now,
                            Email = "milamamaramu@gmail.com",
                            Fb = "https://www.facebook.com/",
                            Google = "https://www.facebook.com/",
                            Inst = "https://www.facebook.com/",
                            Logo = "fsack.png",
                            Map = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2539.228216895754!2d30.513098316050094!3d50.474094979478714!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40d4ce1141d71c09%3A0x868442c1d928bb3c!2z0LLRg9C70LjRhtGPINCi0YPRgNGW0LLRgdGM0LrQsCwgMzEsINCa0LjRl9CyLCDQo9C60YDQsNC40L3QsA!5e0!3m2!1sru!2sus!4v1490966426023",
                            Phone1 = "9999999999999",
                            Phone2 = "9999999999999",
                            Phone3 = "9999999999999",
                            Site = "https://www.facebook.com/",
                            Tw = "https://www.facebook.com/",
                            Video = "https://www.youtube.com/watch?v=1qDbi0_fAHg",
                            Title = "Очень полезно",
                            TitleEu = "Very userfull",
                        });

                    }

                    context.SaveChanges();

                    #endregion

                    #region Помощь бизнесу

                    for (int i = 0; i < 20; i++)
                    {


                        context.BusinessHelperses.Add(new BusinessHelpers
                        {
                            Description = "<span>Тестовая надпись все дела, Путин ХУйло, лалалалал лалал лала :)</span>",
                            DescriptionEn = "<span>Putin huilo lal al aala la la lol  :)</span>",
                            Address = "Ул.УбитогоСепара 666 кв 66",
                            AddressEn = "killSepar 666",
                            City = "Киев",
                            CityEn = "Kiev",
                            DateAdd = DateTime.Now,
                            Email = "milamamaramu@gmail.com",
                            Fb = "https://www.facebook.com/",
                            Google = "https://www.facebook.com/",
                            Inst = "https://www.facebook.com/",
                            Logo = "fsack.png",
                            Map = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2539.228216895754!2d30.513098316050094!3d50.474094979478714!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40d4ce1141d71c09%3A0x868442c1d928bb3c!2z0LLRg9C70LjRhtGPINCi0YPRgNGW0LLRgdGM0LrQsCwgMzEsINCa0LjRl9CyLCDQo9C60YDQsNC40L3QsA!5e0!3m2!1sru!2sus!4v1490966426023",
                            Phone1 = "9999999999999",
                            Phone2 = "9999999999999",
                            Phone3 = "9999999999999",
                            Site = "https://www.facebook.com/",
                            Tw = "https://www.facebook.com/",
                            Title = "Допомога",
                            TitleEu = "Helper",
                        });
                    }

                    context.SaveChanges();

                    #endregion

                    #region Вакансии

                    for (int i = 0; i < 20; i++)
                    {
                        context.Jobses.Add(new Jobs
                        {
                            DescriptionJobs = "<span>Тестовая надпись все дела, Путин ХУйло, лалалалал лалал лала :)</span>",
                            DescriptionEnJobs = "<span>Putin huilo lal al aala la la lol  :)</span>",
                            Address = "Ул.УбитогоСепара 666 кв 66",
                            AddressEn = "killSepar 666",
                            City = "Киев",
                            CityEn = "Kiev",
                            DateAdd = DateTime.Now,
                            Fb = "https://www.facebook.com/",
                            Google = "https://www.facebook.com/",
                            Inst = "https://www.facebook.com/",
                            Map = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2539.228216895754!2d30.513098316050094!3d50.474094979478714!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40d4ce1141d71c09%3A0x868442c1d928bb3c!2z0LLRg9C70LjRhtGPINCi0YPRgNGW0LLRgdGM0LrQsCwgMzEsINCa0LjRl9CyLCDQo9C60YDQsNC40L3QsA!5e0!3m2!1sru!2sus!4v1490966426023",
                            Phone1 = "9999999999999",
                            Phone2 = "9999999999999",
                            Phone3 = "9999999999999",
                            Site = "https://www.facebook.com/",
                            Tw = "https://www.facebook.com/",
                            EmailJobs = "milamamaramu@gmail.com",
                            LogoJobs = "fsack.png",
                            TitleEuJobs = "Name",
                            TitleJobs = "Название"
                        });
                    }

                    context.SaveChanges();

                    #endregion

                    #region Про нас

                    context.AboutUses.Add(new AboutUs
                    {
                        Description = "вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! вот такие мы! ",
                        Phone1 = "232323232232323",
                        Phone3 = "45345345353553",
                        Phone2 = "42424244242424",
                        Email = "milaNet@ukr.net",
                        DescriptionEn = "Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! "
                    });
                    context.SaveChanges();

                    for (int i = 0; i < 3; i++)
                    {


                        context.TeamMembers.Add(new TeamMember
                        {
                            Description = "Гусь в метро, ездит в метро! Гусь в метро, ездит в метро! Гусь в метро, ездит в метро! Гусь в метро, ездит в метро! Гусь в метро, ездит в метро! Гусь в метро, ездит в метро! ",
                            Google = "https://www.facebook.com/",
                            Fb = "https://www.facebook.com/",
                            Inst = "https://www.facebook.com/",
                            Tw = "https://www.facebook.com/",
                            Phone1 = "234234234234234",
                            Phone2 = "232323232323232",
                            City = "Киев",
                            Email = "milonet@ukr.net",
                            Name = "Гусь Метровый",
                            Photo = "fsack.png",
                            DescriptionEn = "Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! Yo! ",
                            NameEn = "Gus Metrovii",
                            CityEn = "Kiev"

                        });
                    }

                    context.SaveChanges();

                    #endregion
                }
            }

            return "Гтово!";
        }
    }
}