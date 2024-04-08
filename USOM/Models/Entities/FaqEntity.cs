using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace USOM
{
 
    [Table("Faq")]
    public class FaqEntity : BaseEntity
    {
        public string Description { get; set; }

    }
}
