using System.ComponentModel.DataAnnotations.Schema;
namespace USOM
{
	[Table("GalleryVideo")]
	public class GalleryVideoEntity : BaseEntity
	{

        public string YoutubeVideoLink { get; set; }
    }
}