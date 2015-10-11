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

namespace Heat.Controllers
{
	[Authorize()]
	public class SearchController : Controller
	{

		[HttpPost()]
		public ActionResult Index(string searchquery, string fromcontroller)
		{
			switch (fromcontroller) {
				case "Customers":
					ViewBag.message = "Search results for " + searchquery + " in Customers";
					break;
				case "PlantClasses":
					ViewBag.message = "Search results for " + searchquery + " in  PlantClasses";
					break;
				case "Plants":
					ViewBag.message = "Search results for " + searchquery + " in  Plant";
					break;
				case "PlantTypes":
					ViewBag.message = "Search results for " + searchquery + " in  PlantTypes";

					break;
			}
			return View();
		}
	}
}
