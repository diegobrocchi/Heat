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
	public class EditCustomerViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Required()]
		[Display(Name = "Nome")]
		public string Name { get; set; }
		[Display(Name = "Indirizzo")]
		public string Address { get; set; }
		[Display(Name = "Città")]
		public string City { get; set; }
		[Display(Name = "CAP")]
		public string PostalCode { get; set; }
		[Display(Name = "Provincia")]
		public string District { get; set; }
		[Display(Name = "Telefono 1")]
		public string Telephone1 { get; set; }
		[Display(Name = "Telefono 2")]
		public string Telephone2 { get; set; }
		[Display(Name = "Telefono 3")]
		public string Telephone3 { get; set; }
		[Display(Name = "Codice fiscale")]
		public string Taxcode { get; set; }
		[Display(Name = "Partita IVA")]
		public string VAT_Number { get; set; }
		[Display(Name = "IBAN")]
		public string IBAN { get; set; }

		[EmailAddress()]
		public string EMail { get; set; }
		[Url()]
		public string Website { get; set; }

		[Display(Name = "Abilitato")]
		public bool IsEnabled { get; set; }

		[Display(Name = "Note")]
		[DataType(DataType.MultilineText)]
		public string Note { get; set; }

	}
}

