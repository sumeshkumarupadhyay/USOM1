using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace USOM
{
    [Table("ServiceCategory")]
    public class ServiceCategoryEntity : BaseEntity
    {
        public bool AddOnMenu { get; set; }
    }

    [Table("Service")]
    public class ServiceEntity : BaseEntity
    {
        [ForeignKey("ServiceCategory")]
        public int ServiceCategoryId { get; set; }

        public ServiceCategoryEntity ServiceCategory { get; set; }

        public string Excerpt { get; set; }

        public string Description { get; set; }
        public string Price { get; set; }

		public bool IsFeatured { get; set; }
	}
}
