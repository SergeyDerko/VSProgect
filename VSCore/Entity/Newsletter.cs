using System;
using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// Рассылка писем
    /// </summary>
    public class Newsletter
    {
        [Key]
        public int NewsletterId { get; set; }
        public string Email { get; set; }
        public string Meta1 { get; set; }
        public string Meta2 { get; set; }
        public string Meta3 { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
