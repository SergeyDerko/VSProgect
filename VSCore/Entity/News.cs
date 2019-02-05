using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// новости
    /// </summary>
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Заголовок En
        /// </summary>
        public string TitleEn { get; set; }
        /// <summary>
        /// Тело HTML
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Тело HTML En
        /// </summary>
        public string BodyEn { get; set; }
        /// <summary>
        /// ссылка на новость на сторонних сайтах
        /// </summary>
        public string DetailUrl { get; set; }
        public DateTime DateNews { get; set; }
        public virtual ICollection<Video> Videos { get; set; }


    }
}
