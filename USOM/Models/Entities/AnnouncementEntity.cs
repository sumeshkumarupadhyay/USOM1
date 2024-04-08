using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace USOM
{
    [Table("AnnouncementCategory")]
    public class AnnouncementCategoryEntity : BaseEntity
    {
        public bool AddOnMenu { get; set; }
    }

    [Table("Announcement")]
    public class AnnouncementEntity : BaseEntity
    {
        [ForeignKey("AnnouncementCategory")]
        public int AnnouncementCategoryId { get; set; }

        public AnnouncementCategoryEntity AnnouncementCategory { get; set; }
    }
}
