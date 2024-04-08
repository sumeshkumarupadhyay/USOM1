using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USOM
{
	

	[Table("Publication")]
	public class PublicationEntity : BaseEntity
	{
        public string DocumentLink { get; set; }

       

	}
}