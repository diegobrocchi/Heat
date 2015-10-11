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
	/// Rappresenta una operazione di manutenzione di impianto per la caldaia.
	/// </summary>
	/// <remarks></remarks>
	public class BoilerService
	{

		public int ID { get; set; }
		public Boiler Boiler { get; set; }
		public BoilerServiceType Type { get; set; }

		/// <summary>
		/// Data della ultima manutenzione eseguita.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public DateTime PreviousServiceDate { get; set; }

		/// <summary>
		/// Periodicità della manutenzione.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public Periodicity Periodicity { get; set; }

		/// <summary>
		/// Scadenza legale della manutenzione.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public DateTime LegalExpirationDate { get; set; }

		/// <summary>
		/// Data programmata di esecuzione della manutenzione. 
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public DateTime PlannedServiceDate { get; set; }

	}
}
