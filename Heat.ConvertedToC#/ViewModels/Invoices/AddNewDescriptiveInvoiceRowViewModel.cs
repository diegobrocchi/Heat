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
	public class AddNewDescriptiveInvoiceRowViewModel
	{
		public int InvoiceID { get; set; }

		[Required()]
		[Display(Name = "Descrizione")]
		[DataType(DataType.MultilineText)]
		public string RowDescription { get; set; }

		[Required()]
		[Display(name = "Quantità")]
		[Range(0, int.MaxValue)]
		public float Quantity { get; set; }

		[Display(name = "Prezzo")]
		[DataType(DataType.Currency)]
		public decimal UnitPrice { get; set; }

		[Display(name = "IVA")]
		public double VAT { get; set; }

		[Display(name = "Sconto 1")]
		public float Discount1 { get; set; }

		[Display(name = "Sconto 2")]
		public float Discount2 { get; set; }

		[Display(name = "Sconto 3")]
		public float Discount3 { get; set; }


	}
}

