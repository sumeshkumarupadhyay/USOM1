using System.Collections.Generic;
using System.Data.Entity;
using USOM;



namespace USOM
{
    public class HomeViewModel
    {
        public IList<SliderEntity> Sliders { get; set; }
        public IList<AnnualReportEntity> AnnualReports { get; set; }
        public IList<GalleryEntity> Galleries { get; set; }
        public IList<ProductsEntity> Products { get; set; }
        public IList<AnnouncementEntity> Announcements { get; set; }
        public IList<ServiceEntity> Services { get; set; }
        public IList<AnnouncementEntity> FeaturedAnnouncements { get; set; }
        public IList<AnnouncementCategoryEntity> AnnouncementCategories { get; set; }
        public IList<ServiceCategoryEntity> ServiceCategories { get; set; }
        public IList<ServiceEntity> Service { get; set; }
        public IList<EventTypeEntity> EventTypes { get; set; }
        public IList<EventEntity> Events{ get; set; }
        //public IList<PublicationTypeEntity> PublicationTypes{ get; set; }
		public IList<BlogEntity> FeaturedBlogs { get; set; }
		public IList<PublicationEntity> publications{ get; set; }
        public IList<BlogCategoryEntity> BlogCategories{ get; set; }
        public IList<BlogEntity> Blogs{ get; set; }
        public IList<FaqEntity> Faq { get; set; }
        public IList<SupporterEntity> supporters { get; set; }
        public IList<HistoryEntity> Histories { get; set; }
        public IList<GalleryVideoEntity> GalleryVideos { get; set; }
        public IList<TestimonialEntity> Testimonials { get; set; }
        public IList<ContactUsEntity> ContactUs { get; set; }
       public HeaderDataCount HeaderData { get; set; }
    }

    public class HeaderDataCount
    {
        public long RoomCount { get; set; }
        public long GalleryCount { get; set; }
        public long ServiceCount { get; set; }
        public long EnquiryCount { get; set; }
        public long MenuCount { get; set; }
        public IList<CCAvanuePaymentResponseEntity> DayWiseCollection { get; set; }
        public IList<CCAvanuePaymentResponseEntity> MonthWiseCollection { get; set; }
        public IList<CCAvanuePaymentResponseEntity> WeekWiseCollection { get; set; }
        public IList<ContactUsEntity> Contacts { get; set; }
        public IList<TestimonialEntity> Testimonials { get; set; }
    }
}