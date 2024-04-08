using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USOM { 
	[Table("BlogCategory")]
	public class BlogCategoryEntity : BaseEntity
	{
		public bool AddOnMenu { get; set; }
	}

	[Table("Blog")]
	public class BlogEntity : BaseEntity
	{
		[ForeignKey("BlogCategory")]
		public int BlogCategoryId { get; set; }

		public BlogCategoryEntity BlogCategory { get; set; }

		public string Excerpt { get; set; }
		public string PostedBy { get; set; }

		public string Description { get; set; }

		public string YoutubeLink { get; set; }

		public string Tags { get; set; }
		public bool IsFeatured { get; set; }
	}
}