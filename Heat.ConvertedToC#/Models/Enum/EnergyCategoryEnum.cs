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
using System.ComponentModel.DataAnnotations;
namespace Heat
{
	public enum EnergyCategoryEnum
	{
		[Display(Name = "E.1")]
		E1 = 1,

		[Display(Name = "E.2")]
		E2 = 2,

		[Display(Name = "E.3")]
		E3 = 3,

		[Display(Name = "E.4")]
		E4 = 4,

		[Display(Name = "E.5")]
		E5 = 5,

		[Display(Name = "E.6")]
		E6 = 6,

		[Display(Name = "E.7")]
		E7 = 7,

		[Display(Name = "E.8")]
		E8 = 8

	}
}
