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
namespace Heat
{

	public static class EnumerableExtensions
	{

		[Extension()]
		public static IEnumerable<SelectListItem> ToSelectListItems<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value, string selectedValue)
		{
			return items.ToSelectListItems(name, value, selectedValue, false);
		}

		[Extension()]
		public static IEnumerable<SelectListItem> ToSelectListItems<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value, string selectedValue, bool includeNotApplicable, string notApplicableValue = "", string notApplicableText = "(Not Applicable)")
		{
			return items.ToSelectListItems(name, value, x => value(x) == selectedValue, includeNotApplicable, notApplicableValue, notApplicableText);
		}

		[Extension()]
		public static IEnumerable<SelectListItem> ToSelectListItems<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value, Func<T, bool> isSelected)
		{
			return items.ToSelectListItems(name, value, isSelected, false);
		}

		[Extension()]
		public static IEnumerable<SelectListItem> ToSelectListItems<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value, Func<T, bool> isSelected, bool includeNotApplicable, string notApplicableValue = "", string notApplicableText = "(Not Applicable)")
		{
			if (includeNotApplicable) {
				var returnItems = new List<SelectListItem> { new SelectListItem {
					Text = notApplicableText,
					Value = notApplicableValue,
					Selected = false
				} };

				if (items != null) {
					returnItems.AddRange(items.Select(item => new SelectListItem {
						Text = name(item),
						Value = value(item),
						Selected = isSelected(item)
					}));
				}
				return returnItems;
			}

			if (items == null) {
				return new List<SelectListItem>();
			}

			return items.Select(item => new SelectListItem {
				Text = name(item),
				Value = value(item),
				Selected = isSelected(item)
			});
		}

		[Extension()]
		public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value, IEnumerable<int> selectedValues)
		{
			if (selectedValues == null) {
				selectedValues = new List<int>();
			}
			return items.ToMultiSelectListItems(name, value, selectedValues.Select(x => x.ToString()));
		}

		[Extension()]
		public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value, IEnumerable<long> selectedValues)
		{
			if (selectedValues == null) {
				selectedValues = new List<long>();
			}
			return items.ToMultiSelectListItems(name, value, selectedValues.Select(x => x.ToString()));
		}

		[Extension()]
		public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value, IEnumerable<double> selectedValues)
		{
			if (selectedValues == null) {
				selectedValues = new List<double>();
			}
			return items.ToMultiSelectListItems(name, value, selectedValues.Select(x => x.ToString()));
		}

		[Extension()]
		public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value, IEnumerable<decimal> selectedValues)
		{
			if (selectedValues == null) {
				selectedValues = new List<decimal>();
			}
			return items.ToMultiSelectListItems(name, value, selectedValues.Select(x => x.ToString()));
		}

		[System.Runtime.CompilerServices.Extension()]
		public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value, IEnumerable<string> selectedValues)
		{
			if (items == null) {
				return new List<SelectListItem>();
			}

			if (selectedValues == null) {
				selectedValues = new List<string>();
			}

			return items.ToMultiSelectListItems(name, value, x => selectedValues.Contains(value(x)));
		}

		[Extension()]
		public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value, Func<T, bool> isSelected)
		{
			if (items == null) {
				return new List<SelectListItem>();
			}

			return items.Select(item => new SelectListItem {
				Text = name(item),
				Value = value(item),
				Selected = isSelected(item)
			});
		}

	}
}

