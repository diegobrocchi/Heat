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
	/// Un modello per la visualizzazione della griglia delle fatture confermate. 
	/// </summary>
	/// <remarks></remarks>
	public class confirmedInvoicesGridViewModel
	{
		public int ID { get; set; }

		[Display(name = "Cliente")]
		public string Customer { get; set; }

		[Display(name = "Data emissione")]
		[DisplayFormat(dataformatstring = "{0:d}")]
		public DateTime InvoiceDate { get; set; }

		[Display(name = "Numero")]
		public string InvoiceNumber { get; set; }

		[Display(name = "TOTALE")]
		public decimal TotalAmount { get; set; }

		[Display(name = "IVA")]
		public decimal TaxesAmount { get; set; }

		[Display(name = "Imponibile")]
		public decimal TaxableAmount { get; set; }

		[Display(name = "Pagamento")]
		public string Payment { get; set; }


	}
}

