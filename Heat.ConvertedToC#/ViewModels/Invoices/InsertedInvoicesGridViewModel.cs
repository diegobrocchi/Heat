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


namespace Heat.ViewModels.Invoices
{
	/// <summary>
	/// Modello per la visualizzazione della griglia delle fatture inserite (ma non confermate).
	/// </summary>
	/// <remarks></remarks>
	public class InsertedInvoicesGridViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Cliente")]
		public string Customer { get; set; }

		[Display(Name = "Data emissione")]
		[DisplayFormat(DataFormatString = "{0: d}")]
		public DateTime InvoiceDate { get; set; }

		[Display(Name = "Numero Provvisorio")]
		public string InvoiceNumber { get; set; }

		[Display(Name = "Numero righe")]
		public int RowCount { get; set; }

	}

}
