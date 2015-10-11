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
	/// Una riga fattura intesa come modello da presentare nella view: la fattura ha righe che possono essere di tipo differente: Prodotto o Descrittiva.
	/// Una riga di tipo Presentation costituisce una versione omogenea, di sola lettura, per i due tipi.
	/// </summary>
	/// <remarks></remarks>
	public class PresentationInvoiceRowViewModel
	{
		//Inherits Models.InvoiceRow

		//le proprietà ID + RowType costituiscono la chiave primaria dell'entità.

		public InvoiceRowType RowType { get; set; }

		public string ProductCode { get; set; }
		public string Description { get; set; }

		[Key()]
		public int ID { get; set; }

		public int InvoiceID { get; set; }

		[Display(name = "Item")]
		public int Item { get; set; }

		[Display(name = "Codice")]
		public string SKU { get; set; }

		[Display(name = "Prodotto")]
		public string Product { get; set; }

		[Display(name = "Quantità")]
		public float Quantity { get; set; }

		[Display(name = "Prezzo")]
		public decimal UnitPrice { get; set; }

		[Display(name = "IVA")]
		public double VAT { get; set; }

		[Display(name = "Sconto 1")]
		public float Discount1 { get; set; }

		[Display(name = "Sconto 2")]
		public float Discount2 { get; set; }

		[Display(name = "Sconto 3")]
		public float Discount3 { get; set; }

		[Display(name = "Totale imponibile")]
		public decimal TotalBeforeTax { get; set; }

		[Display(name = "TOTALE")]
		public decimal Total { get; set; }

	}

	public enum InvoiceRowType
	{
		DescriptiveRow = 0,
		ProductRow = 1
	}
}

