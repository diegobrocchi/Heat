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

	public enum Periodicity
	{
		[Display(name = "Nessuna")]
		None = 0,
		[Display(name = "Giornaliera")]
		Daily = 1,
		[Display(name = "Settimanale")]
		Weekly = 2,
		[Display(name = "Mensile")]
		Monthly = 3,
		[Display(name = "Trimestrale")]
		Quarterly = 4,
		[Display(name = "Annuale")]
		Yearly = 5,
		[Display(name = "Biennale")]
		Biennial = 6,
		[Display(name = "Triennale")]
		Three_year = 7,
		[Display(name = "Quadriennale")]
		Four_year = 8,
		[Display(name = "Quinquennale")]
		quinquennial = 9

	}
}
