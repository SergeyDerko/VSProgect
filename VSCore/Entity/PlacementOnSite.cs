using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSCore.Entity
{
    public class PlacementOnSite
    {
        [Key]
        public int Id { get; set; }

        public string NameBrand { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        /// <summary>
        /// Имя-Фамилия владельца
        /// </summary>
        public string NameDirector { get; set; }

        /// <summary>
        /// Описание бизнеса
        /// </summary>
        public string Deskription { get; set; }

        /// <summary>
        /// Пример бизнеса
        /// </summary>
        public int IdBusnessAsExample { get; set; }

        /// <summary>
        /// Суть бизнеса
        /// </summary>
        public string BrandSens { get; set; }

        /// <summary>
        /// История создания бизнеса
        /// </summary>
        public string HistoryOfBrand { get; set; }

        /// <summary>
        /// ФИО и контакты кому звонить для пояснений
        /// </summary>
        public string ContactToAnsver { get; set; }

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
        public DateTime Date { get; set; }
    }
}
