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

        public string Name { get; set; }
        public string NameEn { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
    }
}
