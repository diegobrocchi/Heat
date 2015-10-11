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

namespace Heat.ViewModels.Customers
{
	public class IndexCustomerGridViewModel
	{
		[Key()]
		public int ID { get; set; }
		[Required()]
		[Display(name = "Nome")]
		public string Name { get; set; }
		[Display(name = "Indirizzo")]
		public string Address { get; set; }
		[Display(name = "Città")]
		public string City { get; set; }
		[Display(Name = "CAP")]
		public string PostalCode { get; set; }
		[Display(name = "Provincia")]
		public string District { get; set; }

		[Display(name = "Telefono 1")]
		public string Telephone1 { get; set; }
		[Display(name = "Telefono 2")]
		public string Telephone2 { get; set; }
		[Display(name = "Telefono 3")]
		public string Telephone3 { get; set; }
		[Display(name = "Codice fiscale")]
		public string Taxcode { get; set; }
		[Display(name = "Partita IVA")]
		public string VAT_Number { get; set; }
		[Display(name = "IBAN")]
		public string IBAN { get; set; }

		[EmailAddress()]
		public string EMail { get; set; }
		[Url()]
		public string Website { get; set; }

		public bool IsEnabled { get; set; }
		public DateTime CreationDate { get; set; }
		public Nullable<DateTime> EnableDate { get; set; }
		public Nullable<DateTime> DisableDate { get; set; }
	}
}

