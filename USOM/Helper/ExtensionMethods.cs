using System;
using System.Collections;
using System.Web.Mvc;
using System.Linq;

namespace USOM
{
	public static class ExtensionMethods
	{
		private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
		public static DateTime GetLocal(this DateTime dateTime)
		{
			if (dateTime == DateTime.MinValue)
			{
				dateTime = DateTime.UtcNow.GetLocal();
			}
			return TimeZoneInfo.ConvertTimeFromUtc(dateTime, INDIAN_ZONE);
		}

		public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
		   where TEnum : struct, IComparable, IFormattable, IConvertible
		{
			var values = from TEnum e in Enum.GetValues(typeof(TEnum))
						 select new { Id = e, Name = e.ToString() };
			return new SelectList(values, "Id", "Name", enumObj);
		}

		public static T ToEnum<T>(this string value)
		{
			return (T)Enum.Parse(typeof(T), value, true);
		}

		public static T ToEnum<T>(this int value)
		{
			var name = Enum.GetName(typeof(T), value);
			return name.ToEnum<T>();
		}
	}
}