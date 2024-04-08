using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USOM
{
    [Table("Donation")]
    public class DonationEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Message { get; set; }
        public string PinCode { get; set; }
        public double Amount { get; set; }
        public string BankReferenceId { get; set; }
        public string TransactionId { get; set; }
        public string OrderStatus { get; set; }

        public string PanNumber { get; set; }

    }
}
