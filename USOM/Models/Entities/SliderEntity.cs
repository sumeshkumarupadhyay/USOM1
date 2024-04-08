using System.ComponentModel.DataAnnotations.Schema;

namespace USOM
{
	[Table("Slider")]
	public class SliderEntity : BaseEntity
	{
        public string Captions { get; set; }
        public string SubCaptions { get; set; }
    }
}