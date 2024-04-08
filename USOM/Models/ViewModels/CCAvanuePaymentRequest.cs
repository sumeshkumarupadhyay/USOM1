using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USOM
{
    public class CCAvanuePaymentRequest
    {
        public string OrderId { get; set; }
        public string Amount { get; set; }
        public string BillingName { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string BillingTelephone { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Message { get; set; }
        public string PinCode { get; set; }

        public string ShippingName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingMessage { get; set; }
        public string ShippingPinCode { get; set; }
        public string ShippingPhoneNumber { get; set; }
        public string PanNumber { get; set; }

    }
    public class CCAvanuePaymentResponse
    {
        public string OrderId { get; set; }

        public string TrackingId { get; set; }

        public string BankRefNumber { get; set; }

        public string OrderStatus { get; set; }

        public string FailureMessage { get; set; }

        public string PaymentMode { get; set; }

        public string CardName { get; set; }

        public string StatusCode { get; set; }

        public string StatusMessage { get; set; }
        public string Message { get; set; }

        public string Currency { get; set; }

        public string Amount { get; set; }

        public string TransactionDate { get; set; }

        public string BinCountry { get; set; }


        public override string ToString()
        {
            string logMessage = $"OrderId : {OrderId}, TrackingId : {TrackingId}, BankRefNumber : {BankRefNumber}, OrderStatus : {OrderStatus}, FailureMessage : {FailureMessage}, PaymentMode : {PaymentMode}, CardName : {CardName}, StatusCode : {StatusCode}, StatusMessage : {StatusMessage}, Message : {Message}, Currency : {Currency}, Amount : {Amount}, TransactionDate : {TransactionDate}, BinCountry : {BinCountry}";
            return logMessage;
        }
    }
}
