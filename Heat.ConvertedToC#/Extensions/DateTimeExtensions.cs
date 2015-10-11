using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.CompilerServices;
using System.Globalization;
namespace Heat
{

	public static class DateTimeExtensions
	{
		[Extension()]
		public static DateTime EndOfDay(DateTime currentDate)
		{
			return new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59, 999);
		}

		[Extension()]
		public static DateTime EndOfWeek(DateTime currentDate)
		{
			DateTime lastDayOfWeek = default(DateTime);
			lastDayOfWeek = currentDate.AddDays(-currentDate.DayOfWeek).AddDays(7);
			return new DateTime(lastDayOfWeek.Year, lastDayOfWeek.Month, lastDayOfWeek.Day, 23, 59, 59, 999);

		}

		[Extension()]
		public static DateTime EndOfMonth(DateTime currentDate)
		{
			return new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month), 23, 59, 59, 999);
		}

		[Extension()]
		public static DateTime EndOfQuarter(DateTime currentDate)
		{
			switch (currentDate.Month) {
				case  <=3: // ERROR: Case labels with binary operators are unsupported : LessThanOrEqual
3:
					return new DateTime(currentDate.Year, 3, 31, 23, 59, 59, 999);
				case  // ERROR: Case labels with binary operators are unsupported : LessThanOrEqual
6:
					return new DateTime(currentDate.Year, 6, 30, 23, 59, 59, 999);
				case  // ERROR: Case labels with binary operators are unsupported : LessThanOrEqual
9:
					return new DateTime(currentDate.Year, 9, 30, 23, 59, 59, 999);
				default:
					return new DateTime(currentDate.Year, 12, 31, 23, 59, 59, 999);
			}
		}

		[Extension()]
		public static DateTime EndOfYear(DateTime currentDate)
		{
			int year = currentDate.Year;

			return new DateTime(year, 12, 31, 23, 59, 59, 999);


		}

		[Extension()]
		public static int WeekOfTheYear(DateTime currentDate)
		{
			DayOfWeek day = currentDate.DayOfWeek;

			if (day >= DayOfWeek.Monday & day <= DayOfWeek.Wednesday) {
				currentDate = currentDate.AddDays(3);
			}

			return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}
	}
}


