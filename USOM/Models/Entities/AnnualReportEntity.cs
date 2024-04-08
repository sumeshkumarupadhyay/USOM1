using System.ComponentModel.DataAnnotations.Schema;

namespace USOM
{
	[Table("AnnualReport")]
	public class AnnualReportEntity : BaseEntity
	{
		public string DocumentLink { get; set; }
		public string YearofDocument { get; set; }
    }
}