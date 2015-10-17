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
using Heat.Models;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Invoices
{

	/// <summary>
	/// Modello 
	/// </summary>
	/// <remarks></remarks>
	public class InvoiceCreateViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Cliente")]
		public string CustomerName { get; set; }

		[Display(Name = "Numero documento")]
		public string TempNumber { get; set; }

		[Display(Name = "Data emissione")]
		public System.DateTime EmissionDate { get; set; }


	}

}

