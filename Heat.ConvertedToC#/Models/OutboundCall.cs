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
namespace Heat.Models
{
	/// <summary>
	/// Rappresenta una chiamata ad un contatto per fissare un appuntamento.
	/// </summary>
	public class OutboundCall
	{
		public int ID { get; set; }
		public DateTime CallDate { get; set; }
		public int ContactID { get; set; }
		public virtual Contact Contact { get; set; }
		public int ResultID { get; set; }

		/// <summary>
		/// Chi ha eseguito la chiamata
		/// </summary>
		/// <returns></returns>
		public string Login { get; set; }
	}
}
