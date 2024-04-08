using System;
using RestSharp;

namespace USOM.Utilities
{
    public class EmailSender
    {
        public MailKitEmailSenderOptions Options { get; set; }
        public EmailSender()
        {
            this.Options = GetMailConfiguration();
        }

        public void SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Execute(email, subject, htmlMessage);
        }

        public MailKitEmailSenderOptions GetMailConfiguration()
        {
            return new MailKitEmailSenderOptions
            {
                Host_Address = "smtp.hostinger.com",
                Host_Port = 465,
                Host_Username = "support@annadacollege.ac.in",
                Host_Password = "Annada@123",
                Sender_EMail = "support@annadacollege.ac.in",
                Sender_Name = "Annada College Hazaribagh"
            };
        }
 
        public void Execute(string to, string subject, string htmlmessage)
        {
            var client = new RestClient("http://mailservice.cubeclickcloud.com/");

            // Create a RestRequest specifying the endpoint and method (GET, POST, etc.)
            var request = new RestRequest("/SendEmail", Method.Post);

            // Add parameters if needed
            request.AddParameter("to", to);
            request.AddParameter("subject", subject);
            request.AddParameter("htmlmessage", htmlmessage);

            // Execute the request and get the response
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // API call successful, handle the response
                var content = response.Content;
                // Process the content or log success
                Console.WriteLine("Email sent successfully!");
            }
            else
            {
                // API call failed, handle the error
                var errorMessage = response.ErrorMessage;
                // Log or handle the error scenario
                Console.WriteLine("Email sending failed. Error: " + errorMessage);
            }
        }
    }
}
