using System;

namespace USOM
{
	public class BaseEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public bool IsDeleted { get; set; }

		public string FilePath { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? LastModificationDate { get; set; }

	}
}