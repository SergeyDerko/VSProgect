using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// категории бизнесов
    /// </summary>
    public class CategoryBusness
    {
        [Key]
        public int IdCategory { get; set; }

        /// <summary>
        /// Мелкая картинка
        /// </summary>
        public string Logo { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Meta1 { get; set; }
        public string Meta2 { get; set; }
        public string Meta3 { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}
