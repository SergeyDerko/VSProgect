using System;
using System.Collections.Generic;
using System.Linq;

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
    public class PageModel
    {
        public PageInfo PageInfo { get; set; }
    }
}