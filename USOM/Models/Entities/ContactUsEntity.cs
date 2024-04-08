using System.ComponentModel.DataAnnotations.Schema;

namespace USOM
{
	[Table("ContactUs")]
	public class ContactUsEntity : BaseEntity
	{
		public string Name { get; set; }

		public string Message { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public string Subject { get; set; }

	}
}