using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// Описание команды
    /// </summary>
    public class AboutUs
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
        public string DescriptionEn { get; set; }

        public string Email { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Meta1 { get; set; }
        public string Meta2 { get; set; }
        public string Meta3 { get; set; }
    }
}
