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

        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string ShortBody { get; set; }
        public string ShortBodyEn { get; set; }
        public string Body { get; set; }
        public string BodyEn { get; set; }
        /// <summary>
        /// ссылка на новость на сторонних сайтах
        /// </summary>
        public string Detail { get; set; }
        public DateTime DateNews { get; set; }
        public virtual ICollection<Video> Videos { get; set; }


    }
}
