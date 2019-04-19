using System;
using System.Collections.Generic;
using VSCore.Entity;

namespace VSSite.Models.ForViews
{
   public class PageInfo
    {
        /// <summary>
        /// номер текущей страницы
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// кол-во объектов на странице
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// всего объектов
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// всего страниц
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
    /// <summary>
    /// модель, которая отдается в представение.
    /// </summary>
    public class BusinessPageModel
    {
        public List<CategoryBusness> Category { get; set; }
        public PageInfo PageInfo { get; set; }
        public List<Business> Businesses { get; set; }
        public List<string> Sity { get; set; }
    }
    public class PartnersPageModel
    {
        public List<Partner> Partners { get; set; }
        public PageInfo PageInfo { get; set; }
    }
    public class NewsPageModel
    {
        public List<News> Newses { get; set; }
        public PageInfo PageInfo { get; set; }
    }
    public class BusinessHelpersPageModel
    {
        public List<BusinessHelpers> BusinessHelperses { get; set; }
        public PageInfo PageInfo { get; set; }
    }
    public class JobsHelpersPageModel
    {
        public List<Jobs> Jobses { get; set; }
        public PageInfo PageInfo { get; set; }
    }
    public class UsefulsHelpersPageModel
    {
        public List<Useful> Usefuls { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}