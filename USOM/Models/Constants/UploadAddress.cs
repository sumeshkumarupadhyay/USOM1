using System.Configuration;

namespace USOM
{
    public static class UploadAddress
    {
        public const string Announcement = "~/uploads/announcement";
        public const string Gallery = "~/uploads/Gallery";
        public const string Slider = "~/uploads/slider";
        public const string Testimonial = "~/uploads/testimonial";
        public const string DoctorProfile = "~/uploads/doctorprofile";
        public const string Post = "~/uploads/post";
        public const string Document = "~/uploads/document";
        public const string AnnualReport = "~/uploads/AnnualReport";
        
        public const string Menu = "~/uploads/menu";
        public const string Service = "~/uploads/service";
        public const string Product = "~/uploads/Product";
        public const string Blog = "~/uploads/blog";
        public const string Aboutus = "~/uploads/Aboutus";
        public const string Publication = "~/uploads/Publication";
        public const string Event = "~/uploads/Event";
        public const string supporter = "~/uploads/supporter";
        public const string PublicationType = "~/uploads/PublicationType";

    }

    public static class GetFileAddress
    {
        //public static string Announcement = $"{ConfigurationManager.AppSettings["AppUrl"]}/uploads/Announcement";
        //public static string Gallery = $"{ConfigurationManager.AppSettings["AppUrl"]}/uploads/Gallery";
        //public static string Slider = $"{ConfigurationManager.AppSettings["AppUrl"]}/uploads/notice";
        //public static string Testimonial = $"{ConfigurationManager.AppSettings["AppUrl"]}/uploads/notice";
        // public static string Blog = $"{ConfigurationManager.AppSettings["AppUrl"]}/uploads/notice";
        //public static string Event = $"{ConfigurationManager.AppSettings["AppUrl "]}/uploads/notice";
        //public static string Document = $"{ConfigurationManager.AppSettings["AppUrl "]}/uploads/document";

        public const string Gallery = "/uploads/Gallery";
        public const string Announcement = "/uploads/announcement";
        public const string Slider = "/uploads/slider";
        public const string Testimonial = "/uploads/testimonial";
        public const string Post = "/uploads/post";
        public const string DoctorProfile = "/uploads/doctorprofile";
        public const string Menu = "/uploads/menu";
		public const string Event = "/uploads/Event";

		public const string Publication = "/uploads/Publication";
		public const string Service = "/uploads/service";
        public const string Products = "/uploads/Products";
        public const string Blog = "/uploads/blog";
        public const string Aboutus = "/uploads/Aboutus";
		public const string supporter = "/uploads/supporter";
		public const string AnnualReport = "/uploads/AnnualReport";
		public const string PublicationType = "/uploads/PublicationType";

	}
}