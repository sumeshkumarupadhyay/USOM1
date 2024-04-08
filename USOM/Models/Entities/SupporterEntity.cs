using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace USOM
{
 
    [Table("Supporter")]
    public class SupporterEntity : BaseEntity
    {
        public string Description { get; set; }

    }
}
