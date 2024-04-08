using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace USOM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("USOMConnection", throwIfV1Schema: false)
        {
        }

       

        public IDbSet<ContactUsEntity> ContactUs { get; set; }
        public IDbSet<GalleryEntity> Galleries { get; set; }
       
        public IDbSet<GalleryVideoEntity> GalleryVideos { get; set; }
       
        public IDbSet<TestimonialEntity> FeedBacks { get; set; }
        public IDbSet<ServiceEntity> Services { get; set; }
        public IDbSet<ServiceCategoryEntity> ServiceCategories { get; set; }
        public IDbSet<AnnouncementEntity> Announcements { get; set; }
        public IDbSet<ProductsEntity> Products { get; set; }
        public IDbSet<AnnouncementCategoryEntity> AnnouncementCategories { get; set; }
        public IDbSet<FaqEntity> Faq { get; set; }
        public IDbSet<SupporterEntity> supporters { get; set; }
        public IDbSet<HistoryEntity> Histories { get; set; }

        public IDbSet<SliderEntity> Sliders { get; set; }
        public IDbSet<AnnualReportEntity> AnnualReports { get; set; }
		public IDbSet<EventTypeEntity> EventTypes { get; set; }
		public IDbSet<EventEntity> Events { get; set; }
		//public IDbSet<PublicationTypeEntity> PublicationTypes { get; set; }
		public IDbSet<PublicationEntity> publications { get; set; }
		public IDbSet<BlogCategoryEntity> BlogCategories { get; set; }
		public IDbSet<BlogEntity> Blogs { get; set; }
        public IDbSet<CCAvanuePaymentResponseEntity> CCAvanuePaymentResponse { get; set; }
        public IDbSet<DonationEntity> Donation { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}