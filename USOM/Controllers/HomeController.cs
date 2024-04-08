using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using USOM.Helper;
using USOM.Models;
using USOM.Utilities;
using System.IO;
using System.ComponentModel.DataAnnotations;
using WebGrease.Css.ImageAssemblyAnalysis.LogModel;

namespace USOM
{
    /// <summary>
    /// Create action after gathering the requirements
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        private readonly PaymentGatewayUtility _paymentGatewayUtility = new PaymentGatewayUtility();
        private readonly EmailSender _emailSender = new EmailSender();

        [Route("")]
        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel
            {

            };
            return View(viewModel);
        }

        public ActionResult Navbar()
        {
            HomeViewModel viewModel = new HomeViewModel
            {
                Sliders = QueryRepository<SliderEntity>.GetList("SELECT * FROM Slider order by Id desc"),
                //PublicationTypes = QueryRepository<PublicationTypeEntity>.GetList("SELECT * FROM PublicationType order by Id desc"),
                EventTypes = QueryRepository<EventTypeEntity>.GetList("SELECT * FROM EventType order by Id desc"),
                ServiceCategories = QueryRepository<ServiceCategoryEntity>.GetList("SELECT * FROM Servicecategory order by Id desc"),
                BlogCategories = QueryRepository<BlogCategoryEntity>.GetList("SELECT * FROM Blogcategory order by Id desc"),
                AnnouncementCategories = QueryRepository<AnnouncementCategoryEntity>.GetList("SELECT * FROM AnnouncementCategory order by Id desc"),
                Testimonials = QueryRepository<TestimonialEntity>.GetList("SELECT * FROM Testimonial order by Id desc"),
                Service = QueryRepository<ServiceEntity>.GetList("SELECT * FROM Service order by Id desc"),
                Products = QueryRepository<ProductsEntity>.GetList("SELECT * FROM Products order by Id desc"),

            };
            return PartialView("_Navbar", viewModel);
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactUsViewModel contact)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                ContactUsEntity contactEntity = new ContactUsEntity
                {
                    Name = contact.Name,
                    Email = contact.Email,
                    CreationDate = DateTime.UtcNow.GetLocal(),
                    Message = contact.Message,
                    Subject = contact.Subject,
                    LastModificationDate = DateTime.UtcNow.GetLocal(),
                    PhoneNumber = contact.PhoneNumber,
                };

                context.ContactUs.Add(contactEntity);

                context.SaveChanges();
                //string mail = $@"<p>Hello,</p><p>You have new enquiry from website. Here are the details</p>
                //    <p>Name: {contact.Name} <br/> 
                //    Email: {contact.Email} <br/> 
                //    Message: {contact.Message} <br/> 
                //    Subject: {contact.Subject} <br/>
                //    Phone Number: {contact.PhoneNumber}
                //    </p>

                //    <p>Regards <br/> CubeClick Team</p>";
                //this.SendMail(mail);
                TempData["success"] = true;
                TempData["Message"] = "Your data has been saved. Our team will contact to you soon.";
                return View();
            }

            TempData["success"] = false;
            TempData["Message"] = "Data is incorrect or you failed the recaptcha!";
            return RedirectToAction("Contact");



        }


        public ApplicationDbContext GetContext()
        {
            return context;
        }

        /// <summary>
        /// Send Mail
        /// </summary>
        /// <param name="message"></param>
        //private void SendMail(string message)
        //{
        //	var mimeMessage = new MimeMessage();

        //	mimeMessage.From.Add(MailboxAddress.Parse("noreply@cubeclick.team"));
        //	//anit@technoesgroup.com
        //	mimeMessage.To.Add(MailboxAddress.Parse("deepakkumarsaw13@gmail.com"));

        //	mimeMessage.Subject = "Website Enquiry";
        //	mimeMessage.Body = new TextPart(TextFormat.Html) { Text = message };

        //	// send email
        //	using (var smtp = new SmtpClient())
        //	{
        //		smtp.Connect("mail.cubeclick.team", 587, SecureSocketOptions.Auto);
        //		smtp.Authenticate("noreply@cubeclick.team", "Welcome@123!");
        //		smtp.Send(mimeMessage);
        //		smtp.Disconnect(true);
        //	}
        //}


        [Route("Webgallery")]
        public ActionResult Gallery()
        {
            IList<GalleryEntity> result = context.Galleries.OrderByDescending(a => a.Id).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
        [Route("annual-report")]
        public ActionResult AnnualReport()
        {
            IList<AnnualReportEntity> result = context.AnnualReports.OrderByDescending(a => a.Id).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [Route("Publications-list")]
        public ActionResult Publication()
        {
            IList<PublicationEntity> result = context.publications.OrderByDescending(a => a.Id).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [Route("video-gallery")]
        public ActionResult VideoGallery()
        {
            IList<GalleryVideoEntity> result = context.GalleryVideos.OrderByDescending(a => a.Id).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [Route("Services/{id}/{title}")]
        public ActionResult Service(int id, string title)
        {
            IList<ServiceEntity> result = context.Services.Include(a => a.ServiceCategory).Where(a => a.ServiceCategoryId.Equals(id)).OrderByDescending(a => a.Id).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
        [Route("services-details/{id}/{title}")]
        public ActionResult ServiceDetails(int id, string title)
        {
            var result = context.Services.Where(a => a.Id.Equals(id)).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Services = title;
            ViewBag.ServiceCategory = context.ServiceCategories.ToList();
            ViewBag.Relatedservices = context.Services.Include(a => a.ServiceCategory).ToList();


            return View(result);
        }
        [Route("Event/{id}/{title}")]
        public ActionResult Event(int id, string title)
        {
            IList<EventEntity> result = context.Events.Include(a => a.EventType).Where(a => a.EventTypeId.Equals(id)).OrderByDescending(a => a.Id).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
        [Route("Event-details/{id}/{title}")]
        public ActionResult EventDetails(int id, string title)
        {
            var result = context.Events.Where(a => a.Id.Equals(id)).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Events = title;
            ViewBag.EventType = context.EventTypes.ToList();
            ViewBag.RelatedEvent = context.Events.Include(a => a.EventType).ToList();


            return View(result);
        }
        [Route("blog-list/{id}/{title}")]
        public ActionResult Blogs(int id)
        {
            var result = context.Blogs.Include(a => a.BlogCategory).Where
                (a => a.BlogCategoryId.Equals(id)).OrderByDescending(a => a.LastModificationDate).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Relatedblog = context.Blogs.Include(a => a.BlogCategory).Where(a => a.BlogCategoryId == id).OrderByDescending(a => a.LastModificationDate).ToList();
            ViewBag.blogCategories = context.BlogCategories.OrderByDescending(a => a.LastModificationDate).ToList();

            return View(result);
        }

        [Route("blog-details/{id}/{title}")]
        public ActionResult BlogDetails(int id, string title)
        {
            var result = context.Blogs.Include(a => a.BlogCategory).Where(a => a.Id.Equals(id)).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Blog = title;

            ViewBag.Relatedblog = context.Blogs.Include(a => a.BlogCategory).Where(a => a.BlogCategoryId == result.BlogCategoryId && a.Id != result.Id).ToList();

            return View(result);
        }

        [Route("Announcements/{id}/{title}")]
        public ActionResult Announcement(int id, string title)
        {
            IList<AnnouncementEntity> result = context.Announcements.Include(a => a.AnnouncementCategory).Where(a => a.AnnouncementCategoryId.Equals(id)).OrderByDescending(a => a.Id).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }


        [Route("Announcements-details/{id}/{title}")]
        public ActionResult AnnouncementDetails(int id, string title)
        {
            var result = context.Announcements.Where(a => a.Id.Equals(id)).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Announcement = title;
            ViewBag.AnnouncementCategory = context.AnnouncementCategories.ToList();
            ViewBag.RelatedAnnouncement = context.Announcements.Include(a => a.AnnouncementCategory).Where(a => a.AnnouncementCategoryId == result.AnnouncementCategoryId && a.Id != result.Id).ToList();

            return View(result);
        }

        [Route("aboutus")]
        public ActionResult aboutus()
        {
            return View();
        }
        [Route("patron")]
        public ActionResult patron()
        {
            return View();
        }
        [Route("founder")]
        public ActionResult founder()
        {
            return View();
        }
        [Route("our-suppoter")]
        public ActionResult suppoter()
        {
            IList<SupporterEntity> result = context.supporters.OrderByDescending(a => a.Id).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
        [Route("board-members")]
        public ActionResult boardhistory()
        {
            return View();
        }
        [Route("mission")]
        public ActionResult Mission()
        {
            return View();
        }
        [Route("what-we-do")]
        public ActionResult whatwedo()
        {
            return View();
        }
        [Route("faqs")]
        public ActionResult faq()
        {
            IList<FaqEntity> result = context.Faq.OrderByDescending(a => a.Id).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
        [Route("Historys")]
        public ActionResult History()
        {
            IList<HistoryEntity> result = context.Histories.OrderByDescending(a => a.Id).ToList();
            if (result.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [Route("product-details/{id}/{title}")]
        public ActionResult ProductDetails(int id, string title)
        {
            var result = context.Products.Where(a => a.Id.Equals(id)).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.product = title;
            ViewBag.RelatedProduct = context.Products.Where(a => a.Id.Equals(id)).ToList();

            return View(result);
        }
        [Route("donation")]
        public ActionResult Donations()
        {
            return View();
        }


        //For enail checking
        public string checkEmail(string mail)
        {
            _emailSender.SendEmailAsync(mail, "Donation Confirmation Success", GenerateEmailTemplate(2));
            return "Email Send";
        }
        public ActionResult Payment()
        {
            //For checking Email functionality
            //_emailSender.SendEmailAsync("ag.himanshug@gmail.com", "Donation Confirmation Success", GenerateEmailTemplate(2));
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(DonationViewModel donation)
        {
            DonationEntity donationEntity = new DonationEntity
            {
                Name = donation.Name,
                Email = donation.Email,
                CreationDate = DateTime.UtcNow.GetLocal(),
                //Message = donation.Message,
                Amount = donation.Amount,
                LastModificationDate = DateTime.UtcNow.GetLocal(),
                PhoneNumber = donation.PhoneNumber,
                PinCode = donation.PinCode,
                Country = donation.Country,
                State = donation.State,
                City = donation.City,
                Address = donation.Address,
                //PanNumber=donation.PanNumber,
                OrderStatus = ((int)PaymentStatus.Initiate).ToString(),
            };
            // Check if the message is empty
            if (string.IsNullOrWhiteSpace(donation.Message))
            {
                // If empty, set it to "payment"
                donationEntity.Message = "payment";
            }
            else
            {
                // Otherwise, use the provided message
                donationEntity.Message = donation.Message;
            }

            var result = context.Donation.Add(donationEntity);
            context.SaveChanges();

            CCAvanuePaymentRequest paymentRequest = new CCAvanuePaymentRequest
            {
                Address = donation.Address,
                Amount = donation.Amount.ToString(),
                BillingName = donation.Name,
                BillingTelephone = donation.PhoneNumber,
                Email = donation.Email,
                OrderId = result.Id.ToString(),
                PinCode = donation.PinCode,
                Country = donation.Country,
                State = donation.State,
                City = donation.City,
                //PanNumber = donation.PanNumber,
                Message = donationEntity.Message,
            };

            // Shipping address details
            paymentRequest.ShippingAddress = donation.Address;
            paymentRequest.ShippingName = donation.Name;
            paymentRequest.ShippingPinCode = donation.PinCode;
            paymentRequest.ShippingCountry = donation.Country;
            paymentRequest.ShippingState = donation.State;
            paymentRequest.ShippingCity = donation.City;
            paymentRequest.ShippingPhoneNumber = donation.PhoneNumber;
            //paymentRequest.PanNumber = donation.PanNumber;
            paymentRequest.Message = donationEntity.Message;

            //redirect payment option to payment gateway portal
            return Redirect(GeneratePaymentUrl(paymentRequest));
        }

        [AllowAnonymous]
        public ActionResult PaymentResponse(string encResp)
        {
            CCAvanuePaymentResponse response = _paymentGatewayUtility.DecryptAndSavePaymentResponse(encResp);
            return PaymentConfirmation_Success(response);
        }

        public ActionResult PaymentConfirmation_Success(CCAvanuePaymentResponse modelVM)
        {
            try
            {
                int donationId = Convert.ToInt32(modelVM.OrderId);
                DonationEntity donationDetail = context.Donation.FirstOrDefault(a => a.Id.Equals(donationId));

                if (donationDetail == null || modelVM == null)
                {
                    TempData["success"] = false;
                    TempData["Message"] = "We got failure in response. Please try again!";
                    return RedirectToAction("Payment");
                }
                //Update the DonationEntity on success
                if (modelVM.OrderStatus.Equals("Success", StringComparison.OrdinalIgnoreCase))
                {
                    donationDetail.BankReferenceId = modelVM.BankRefNumber;
                    donationDetail.TransactionId = modelVM.OrderId;
                    donationDetail.OrderStatus = ((int)PaymentStatus.Success).ToString();
                    context.SaveChanges();
                    _emailSender.SendEmailAsync(donationDetail.Email, "Donation Confirmation Success", GenerateEmailTemplate((int)donationId));
                    TempData["success"] = true;
                    TempData["Message"] = "Transaction Completed Succesfully";

                    //create one separate page for success of payment. 
                    //return RedirectToAction("Payment");
                    return RedirectToAction("PaymentSuccess", new { orderId = modelVM.OrderId });
                }
                else
                {
                    //Update the status of transaction and redirect to Donation page
                    donationDetail.OrderStatus = ((int)PaymentStatus.Pending).ToString();
                    context.SaveChanges();
                    TempData["success"] = false;
                    TempData["Message"] = $"Transaction Failed due to {modelVM.FailureMessage}";
                    //create one separate page for failure of payment. 
                    //return RedirectToAction("Payment");
                    return RedirectToAction("PaymentFailure", new {failureReason = modelVM.FailureMessage });
                }
            }
            catch (Exception ex)
            {
                TempData["success"] = false;
                TempData["Message"] = $"Transaction Failed due to {ex.Message}";
                return RedirectToAction("Payment");
            }
        }
        public ActionResult PaymentSuccess(string orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }

        public ActionResult PaymentFailure(string failureReason)
        {
            ViewBag.FailureReason = failureReason;
            return View();
        }

        private string GeneratePaymentUrl(CCAvanuePaymentRequest request)
        {
            if (request != null)
            {
                string paymentRequest = _paymentGatewayUtility.GeneratePaymentRequest(request);
                string secureHash = _paymentGatewayUtility.GenerateSecureHash(paymentRequest);
                return _paymentGatewayUtility.ReturnPaymentUrl(secureHash);
            }
            return null;
        }

        public string GenerateEmailTemplate(int id)
        {
            DonationEntity donationDetail = context.Donation.Where(a => a.Id == id).FirstOrDefault();
            CCAvanuePaymentResponseEntity cCAvanue = null;
            if (donationDetail != null)
            {
                cCAvanue = context.CCAvanuePaymentResponse.Where(a => a.OrderId == donationDetail.TransactionId).FirstOrDefault();
            }
            var webRootPath = Server.MapPath("~/Content/Template/Invoice");
            var filePath = Path.Combine(webRootPath, "gcci.html");
            var builder = String.Empty;

            using (StreamReader SourceReader = System.IO.File.OpenText(filePath))
            {
                builder = SourceReader.ReadToEnd();
            }

            string mailString = string.Format(builder);
            if (cCAvanue != null && donationDetail != null)
            {
                mailString = mailString.Replace("[TransactionMessage]", donationDetail.Message);
                mailString = mailString.Replace("[DonorName]", donationDetail.Name);
                mailString = mailString.Replace("[DonationAmount]", donationDetail.Amount.ToString());
                mailString = mailString.Replace("[DonationDate]", donationDetail.CreationDate.ToString());
                mailString = mailString.Replace("[TransactionId]", donationDetail.TransactionId.ToString());
                mailString = mailString.Replace("[AmountType]", cCAvanue.PaymentMode.ToString());
                mailString = mailString.Replace("[BankReferenceNumber]", cCAvanue.BankRefNumber.ToString());
                //mailString = mailString.Replace("[PanNumber]", donationDetail.PanNumber);
            }
            return mailString;
        }

    }
}