using System;
using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// отделения бизнеса ветеранов
    /// </summary>
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        /// <summary>
        /// Логотип
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// Название бизнесса
        /// </summary>
        public string MainName { get; set; }
        /// <summary>
        /// Название бизнесса En
        /// </summary>
        public string MainNameEn { get; set; }
        /// <summary>
        /// Фото
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// Мыло
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Описание HTML
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Описание HTML En
        /// </summary>
        public string DescriptionEn { get; set; }
        /// <summary>
        /// Адресс сайта
        /// </summary>
        public string Site { get; set; }

        public string Fb { get; set; }

        public string Google { get; set; }

        public string Tw { get; set; }

        public string Inst { get; set; }

        public string Map { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Город En
        /// </summary>
        public string CityEn { get; set; }
        /// <summary>
        /// Адресс
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Адресс En
        /// </summary>
        public string AddressEn { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Phone3 { get; set; }
        public string Meta1 { get; set; }
        public string Meta2 { get; set; }
        public string Meta3 { get; set; }

        public DateTime DateAdd { get; set; }

        public virtual Business Business { get; set; }
    }
}
