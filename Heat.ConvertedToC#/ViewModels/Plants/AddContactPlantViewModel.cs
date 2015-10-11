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
using Heat.Models;

namespace Heat.ViewModels.Plants
{
	public class AddContactPlantViewModel
	{
		public int PlantID { get; set; }

		[Required()]
		[Display(name = "Nominativo")]
		public string Name { get; set; }

		[Display(name = "Tipo contatto")]
		public int AddressTypeID { get; set; }
		public IEnumerable<SelectListItem> AddressTypeList { get; set; }

		[Display(name = "Indirizzo")]
		public string Street { get; set; }

		[Display(name = "Numero civico")]
		public string StreetNumber { get; set; }

		[Display(name = "Località")]
		public string City { get; set; }

		[Display(name = "CAP")]
		public string PostalCode { get; set; }

		[Display(name = "Provincia")]
		public string District { get; set; }


		[Display(name = "Note")]
		[DataType(DataType.MultilineText)]
		public string Note { get; set; }

		[Display(name = "Telefono")]
		public string Phone { get; set; }

		[Display(name = "Cellulare")]
		public string CellPhone { get; set; }

		[Display(name = "Fax")]
		public string Fax { get; set; }

		[Display(name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(name = "Web")]
		[DataType(DataType.Url)]
		public string URL { get; set; }


	}

}
