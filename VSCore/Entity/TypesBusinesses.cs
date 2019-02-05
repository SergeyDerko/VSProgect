using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// Типы бизнесса
    /// </summary>
    public class TypesBusinesses
    {
        [Key]
        public int IdType { get; set; }

        public string Name { get; set; }

        public string NameEn { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}
