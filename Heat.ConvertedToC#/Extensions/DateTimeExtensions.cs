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
		public static DateTime EndOfDay(this DateTime currentDate)
		{
			return new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59, 999);
		}

		public static DateTime EndOfWeek(this DateTime currentDate)
		{
			DateTime lastDayOfWeek = default(DateTime);
			lastDayOfWeek = currentDate.AddDays(- (double) currentDate.DayOfWeek).AddDays(7);
			return new DateTime(lastDayOfWeek.Year, lastDayOfWeek.Month, lastDayOfWeek.Day, 23, 59, 59, 999);

		}

		public static DateTime EndOfMonth(this DateTime currentDate)
		{
			return new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month), 23, 59, 59, 999);
		}

		public static DateTime EndOfQuarter(this DateTime currentDate)
		{
			switch (currentDate.Month) {
                case 1:
                case 2:
                case 3:
					return new DateTime(currentDate.Year, 3, 31, 23, 59, 59, 999);
                case 4:
                case 5:
                case 6:
					return new DateTime(currentDate.Year, 6, 30, 23, 59, 59, 999);
                case 7:
                case 8:
                case 9:
					return new DateTime(currentDate.Year, 9, 30, 23, 59, 59, 999);
				default:
					return new DateTime(currentDate.Year, 12, 31, 23, 59, 59, 999);
			}
		}

		public static DateTime EndOfYear(this DateTime currentDate)
		{
			int year = currentDate.Year;

			return new DateTime(year, 12, 31, 23, 59, 59, 999);


		}

		public static int WeekOfTheYear(this DateTime currentDate)
		{
			DayOfWeek day = currentDate.DayOfWeek;

			if (day >= DayOfWeek.Monday & day <= DayOfWeek.Wednesday) {
				currentDate = currentDate.AddDays(3);
			}

			return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}
	}
}


