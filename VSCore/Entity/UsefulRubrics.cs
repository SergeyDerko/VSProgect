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
        public string Photo { get; set; }

        public virtual ICollection<UsefulRubrics> UsefulRubricses { get; set; }
    }
}
