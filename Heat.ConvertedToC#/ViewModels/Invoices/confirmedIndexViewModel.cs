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

namespace Heat.ViewModels.Invoices
{
	/// <summary>
	/// Modello per la visualizzazione dell'elenco delle fatture in stato CONFERMATO.
	/// </summary>
	/// <remarks></remarks>
	public class confirmedIndexViewModel
	{
		/// <summary>
		/// Stato dei documenti.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public DocumentState State { get; set; }

		/// <summary>
		/// Conteggio delle fatture in stato INSERITO.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public int InsertedInvoiceCount { get; set; }

		/// <summary>
		/// Lista delle fatture CONFERMATE.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public List<confirmedInvoicesGridViewModel> ConfirmedInvoiceList { get; set; }

	}
}

