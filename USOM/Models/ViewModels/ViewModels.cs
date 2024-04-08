using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;

namespace USOM
{
    public class BaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string FilePath { get; set; }

        public bool IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }

        [NotMapped]
        [AllowExtension(Extensions = "png,PNG,jpg,JPG,JPEG,jpeg,gif,pdf,PDF", ErrorMessage = "File type is not supported")]
        public HttpPostedFileBase[] File { get; set; }
    }

    public class ContactUsViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        public string Message { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is requred")]
        
        public string PhoneNumber { get; set; }

        [Required]
        public string Subject { get; set; }
    }

    public class TestimonialViewModel : BaseViewModel
    {
        public string Designation { get; set; }
    }

    public class GalleryViewModel : BaseViewModel
    {
    }
    public class GalleryVideoViewModel : BaseViewModel
    {
        [AllowHtml]
        public string YoutubeVideoLink { get; set; }
    }
    public class ProductViewModel : BaseViewModel
    {
     
        public string Price { get; set; }
    }

    public class AnnouncementCategoryViewModel : BaseViewModel
    {
    }

    public class AnnouncementViewModel : BaseViewModel
    {
        public int AnnouncementCategoryId { get; set; }
        public AnnouncementCategoryViewModel AnnouncementCategory { get; set; }

        
    }
 
    public class FaqViewModel : BaseViewModel
    {
        
    }
    public class supporterViewModel : BaseViewModel
    {
        
    }
    public class HistoryViewModel : BaseViewModel
    {
        public string Year { get; set; }
	}
	public class ServiceCategoryViewModel : BaseViewModel
    {
    }

    public class ServiceViewModel : BaseViewModel
    {
        public int ServiceCategoryId { get; set; }
        public ServiceCategoryViewModel ServicesCategory { get; set; }

        public string Price { get; set; }
        public string Excerpt { get; set; }
		public bool IsFeatured { get; set; }

	}
    public class EventTypeViewModel : BaseViewModel
    {
    }

    public class EventViewModel : BaseViewModel
    {
		public int EventTypeId { get; set; }

		public EventTypeViewModel EventType { get; set; }

		public string Excerpt { get; set; }
		public string YoutubeLink { get; set; }

	}
    public class PublicationTypeViewModel : BaseViewModel
    {
    }

    public class PublicationViewModel : BaseViewModel
    {
        public string DocumentLink { get; set; }
       

	}

	public class BlogCategoryViewModel : BaseViewModel
	{
	}

	public class BlogViewModel : BaseViewModel
	{
		public int BlogCategoryId { get; set; }
		public BlogCategoryViewModel BlogCategory { get; set; }

		public string YoutubeLink { get; set; }
		public string PostedBy { get; set; }

		public string Excerpt { get; set; }

		public string Tags { get; set; }
		public bool IsFeatured { get; set; }
	}



    public class SliderViewModel : BaseViewModel
    {
        public string Captions { get; set; }
        public string SubCaptions { get; set; }
    }
    public class AnnualReportViewModel : BaseViewModel
    {
        public string DocumentLink { get; set; }
        public string YearofDocument { get; set; }

    }



    public class HeaderViewModel : BaseViewModel
    {

    }
    public class DonationViewModel : BaseViewModel
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