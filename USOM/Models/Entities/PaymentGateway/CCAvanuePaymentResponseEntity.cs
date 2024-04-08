using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USOM
{
    [Table("CCAvanuePaymentResponse")]
    public class CCAvanuePaymentResponseEntity : BaseEntity
    {
        public string PaymentResponse { get; set; }

        public string OrderId { get; set; }

        public string TrackingId { get; set; }

        public string BankRefNumber { get; set; }

        public string OrderStatus { get; set; }

        public string FailureMessage { get; set; }

        public string PaymentMode { get; set; }

        public string CardName { get; set; }

        public string StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public string Currency { get; set; }

        public string Amount { get; set; }

        public string TransactionDate { get; set; }

        public string BinCountry { get; set; }
    }
}
