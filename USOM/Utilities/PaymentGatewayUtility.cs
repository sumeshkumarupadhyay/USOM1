using System;
using System.Collections.Specialized;
using System.Web;
using USOM.Models;

namespace USOM
{
    public class PaymentGatewayUtility 
    {
        private readonly CCACrypto ccaCrypto;
        private readonly string workingKey;//put in the 32bit alpha numeric key in the quotes provided here 	
        private readonly string access_key;
        private readonly string merchantId;
        private readonly bool IsTestMode;
        private readonly string TestUrl;
        private readonly string ProdUrl;
        private readonly string PaymentUrl;
        private readonly string AppUrl;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public PaymentGatewayUtility()
        {
            ccaCrypto = new CCACrypto();
            workingKey = "5FA96B8A37555BB9456E41E3B9EF319D";
            access_key = "AVHD83GB50BF79DHFB";
            merchantId = "10921";
            IsTestMode = false;
            TestUrl = "https://test.ccavenue.com";
            ProdUrl = "https://secure.ccavenue.com";
            PaymentUrl = IsTestMode ? TestUrl : ProdUrl;
            
            //Check one more time webUrl
            AppUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/";
        }

        public string RedirectUrl
        {
            get
            {
                string webUrl = AppUrl;
                return $"{webUrl}/Home/PaymentResponse";
            }
        }
        public string FailureRedirectUrl
        {
            get
            {
                string webUrl = AppUrl;
                return $"{webUrl}/Home/PaymentFailure";
            }
        }
        //step - 1
        public string GeneratePaymentRequest(CCAvanuePaymentRequest paymentRequest)
        {
            string notes = Uri.EscapeDataString(paymentRequest.Message);
            if (notes.Length > 500)
            {
                throw new ArgumentException("Billing notes cannot exceed 500 characters.");
            }
            return $@"&merchant_id={merchantId}&order_id={paymentRequest.OrderId}&amount={paymentRequest.Amount}&currency=INR
                        &redirect_url={RedirectUrl}&cancel_url={RedirectUrl}&billing_name={paymentRequest.BillingName}
                        &billing_address={paymentRequest.Address}&billing_tel={paymentRequest.BillingTelephone}
                        &billing_email={paymentRequest.Email} &billing_city={paymentRequest.City}&billing_state={paymentRequest.State}
                 &billing_zip={paymentRequest.PinCode}&billing_country={paymentRequest.Country}
                 &delivery_name={paymentRequest.ShippingName}&delivery_address={paymentRequest.ShippingAddress}
                 &delivery_city={paymentRequest.ShippingCity}&delivery_state={paymentRequest.ShippingState}
                 &delivery_zip={paymentRequest.ShippingPinCode}&delivery_country={paymentRequest.ShippingCountry}
                 &delivery_tel={paymentRequest.ShippingPhoneNumber} {(string.IsNullOrEmpty(notes) ? "" : "&billing_notes=" + notes)}";
        }
        //step - 2
        public string GenerateSecureHash(string ccPaymentRequestParams)
        {
            return ccaCrypto.Encrypt(ccPaymentRequestParams, workingKey);
        }

        //step - 3
        public string ReturnPaymentUrl(string secureHash)
        {
            return $"{PaymentUrl}/transaction.do?command=initiateTransaction&encRequest={secureHash}&access_code={access_key}";
        }

        public CCAvanuePaymentResponse DecryptAndSavePaymentResponse(string response)
        {
            string encResponse = ccaCrypto.Decrypt(response, workingKey);

            NameValueCollection Params = HttpUtility.ParseQueryString(encResponse);

            CCAvanuePaymentResponse responseModel = new CCAvanuePaymentResponse
            {
                OrderId = Params["order_id"],
                TrackingId = Params["tracking_id"],
                BankRefNumber = Params["bank_ref_no"],
                OrderStatus = Params["order_status"],
                FailureMessage = Params["failure_message"],
                PaymentMode = Params["payment_mode"],
                CardName = Params["card_name"],
                StatusCode = Params["status_code"],
                StatusMessage = Params["status_message"],
                Currency = Params["currency"],
                Amount = Params["amount"],
                TransactionDate = Params["trans_date"],
                BinCountry = Params["bin_country"],
            };

            CCAvanuePaymentResponseEntity ccAvanuew = new CCAvanuePaymentResponseEntity
            {
                PaymentResponse = encResponse,
                OrderId = responseModel.OrderId,
                TrackingId = responseModel.TrackingId,
                BankRefNumber = responseModel.BankRefNumber,
                OrderStatus = responseModel.OrderStatus,
                FailureMessage = responseModel.FailureMessage,
                PaymentMode = responseModel.PaymentMode,
                CardName = responseModel.CardName,
                StatusCode = responseModel.StatusCode,
                StatusMessage = responseModel.StatusMessage,
                Currency = responseModel.Currency,
                Amount = responseModel.Amount,
                TransactionDate = responseModel.TransactionDate,
                BinCountry = responseModel.BinCountry,
            };
            _context.CCAvanuePaymentResponse.Add(ccAvanuew);
            _context.SaveChanges();
            return responseModel;
        }

    }
}
