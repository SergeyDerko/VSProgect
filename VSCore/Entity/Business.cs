using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// Бизнесы ветеранов
    /// </summary>
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }
        public string Logo { get; set; }
        public string MainName { get; set; }
        public string MainNameEn { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
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
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// связь с филиалами
        /// </summary>
        public virtual ICollection<Branch>Branches { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
