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

	public enum ThermalUnitKindEnum
	{
		[Display(name = "Gruppo termico singolo")]
		SingleThermalUnit = 1,

		[Display(name = "Tubo/nastro radiante")]
		TubeOrRadiantStrip = 2,

		[Display(name = "Gruppo termico modulare")]
		ModularThermalUnit = 3,

		[Display(name = "Generatore di aria calda")]
		HotAirGenerator = 4

	}
}
