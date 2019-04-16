using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// Рубрики полезной информации
    /// </summary>
    public class UsefulRubrics
    {
        [Key]
        public int RubricsId { get; set; }

        public string RubName { get; set; }
        public string RubNameEu { get; set; }
        public string Picture { get; set; }
        public string Meta1 { get; set; }
        public string Meta2 { get; set; }
        public string Meta3 { get; set; }

        public virtual ICollection<Useful> Usefuls { get; set; }
    }
}
