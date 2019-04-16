using System;
using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// Партнеры
    /// </summary>
    public class Partner
    {
        [Key]
        public int PartnerId { get; set; }
      
        public string Logo { get; set; }
        
        public string Name { get; set; }
       
        public string NameEn { get; set; }
        /// <summary>
        /// HTML
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// HTML En
        /// </summary>
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
        public string Meta { get; set; }
        public string Meta1 { get; set; }
        public string Meta2 { get; set; }
        public string Meta3 { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
