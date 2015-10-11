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
	/// Rappresenta un bruciatore della caldaia; può essere l'unico bruciatore o uno dei tanti bruciatori.
	/// </summary>
	/// <remarks></remarks>
	public class BoilerHeater
	{
		public int ID { get; set; }
		public Boiler Boiler { get; set; }
		public Manifacturer Manifacturer { get; set; }
		public ManifacturerModel Model { get; set; }
		public string SerialNumber { get; set; }
		public float MinimumPowerKW { get; set; }
		public float MaximumPowerKW { get; set; }
		public string CertificationReference { get; set; }

	}
}
