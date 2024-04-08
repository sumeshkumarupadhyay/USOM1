using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace USOM
{
 
    [Table("History")]
    public class HistoryEntity : BaseEntity
    {
        public string Year { get; set; }
        public string Description { get; set; }

    }
}
