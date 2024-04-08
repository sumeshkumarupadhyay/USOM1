using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace USOM
{
    
    [Table("Products")]
    public class ProductsEntity : BaseEntity
    {
        public string Description { get; set; }

        public string Price { get; set; }
       
    }
}
