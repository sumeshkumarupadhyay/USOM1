using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace USOM
{
    [Table("EventType")]
    public class EventTypeEntity : BaseEntity
    {
        public bool AddOnMenu { get; set; }
    }

    [Table("Event")]
    public class EventEntity : BaseEntity
    {
        [ForeignKey("EventType")]
        public int EventTypeId { get; set; }

        public EventTypeEntity  EventType { get; set; }
		
        public string Excerpt { get; set; }

		public string Description { get; set; }

		public string YoutubeLink { get; set; }


	}
}
