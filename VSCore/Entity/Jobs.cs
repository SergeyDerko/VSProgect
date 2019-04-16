using System;
using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// Вакансии
    /// </summary>
    public class Jobs
    {
        [Key]
        public int JobsId { get; set; }

        public string LogoJobs { get; set; }
        public string TitleJobs { get; set; }
        public string TitleEuJobs { get; set; }

        public string EmailJobs { get; set; }
        public string DescriptionJobs { get; set; }
        public string DescriptionEnJobs { get; set; }
        public string Site { get; set; }
        public string Fb { get; set; }
        public string Google { get; set; }
        public string Tw { get; set; }
        public string Inst { get; set; }
        public string Map { get; set; }
        public string City { get; set; }
        public string CityEn { get; set; }
        public string Address { get; set; }
        public string AddressEn { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Meta1 { get; set; }
        public string Meta2 { get; set; }
        public string Meta3 { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
