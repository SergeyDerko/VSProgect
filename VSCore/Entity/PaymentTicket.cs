using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSCore.Entity
{
    /// <summary>
    /// Пожертвования
    /// </summary>
    public class PaymentTicket
    {
        [Key]
        public int Id { get; set; }

        public string Info { get; set; }
        public string Deskription { get; set; }
        public string NamePiople { get; set; }
        public string Email { get; set; }
        public double Sum { get; set; }
        public double RealSum { get; set; }
        public string CurensyTupe { get; set; }
        public string IpAdress { get; set; }
        /// <summary>
        /// 0 - новый, 1-отменен, 2 - подтвержден
        /// </summary>
        public int Status { get; set; }

        public DateTime Date { get; set; }
    }
}
