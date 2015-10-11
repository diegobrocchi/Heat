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
	/// Rappresenta una caldaia
	/// </summary>
	/// <remarks></remarks>
	public class Boiler
	{
		public int ID { get; set; }
		public Manifacturer Manifacturer { get; set; }
		public ManifacturerModel Model { get; set; }
		public string SerialNumber { get; set; }
		public DateTime InstallationDate { get; set; }
		public DateTime FirstStartUp { get; set; }
		public string Warranty { get; set; }
		public DateTime WarrantyExpiration { get; set; }

		/// <summary>
		/// Elenco delle operazioni di manutenzione eseguite sulla caldaia. 
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public List<BoilerService> Services { get; set; }

	}
}
