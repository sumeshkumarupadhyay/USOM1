using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USOM
{
	public class AllowExtensionAttribute : ValidationAttribute
	{
		/// <summary>  
		/// Gets or sets extensions property.  
		/// </summary>  
		public string Extensions { get; set; } = "png,jpg,jpeg,gif,pdf";

		public override bool IsValid(object value)
		{
			List<string> allowedExtensions = Extensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

			bool isValid = true;
			if (value as HttpPostedFileBase[] != null)
			{
				foreach (var item in value as HttpPostedFileBase[])
				{
					// Verification.  
					if (item != null)
					{
						// Initialization.  
						var fileName = item.FileName;

						// Settings.  
						isValid = allowedExtensions.Any(y => fileName.EndsWith(y));

						if (!isValid)
						{
							break;
						}
					}

				}
			}

			// Info  
			return isValid;
		}
	}
}