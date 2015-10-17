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
		[Display(Name = "Nominativo")]
		public string Name { get; set; }

		[Display(Name = "Tipo contatto")]
		public int AddressTypeID { get; set; }
		public IEnumerable<SelectListItem> AddressTypeList { get; set; }

		[Display(Name = "Indirizzo")]
		public string Street { get; set; }

		[Display(Name = "Numero civico")]
		public string StreetNumber { get; set; }

		[Display(Name = "Località")]
		public string City { get; set; }

		[Display(Name = "CAP")]
		public string PostalCode { get; set; }

		[Display(Name = "Provincia")]
		public string District { get; set; }


		[Display(Name = "Note")]
		[DataType(DataType.MultilineText)]
		public string Note { get; set; }

		[Display(Name = "Telefono")]
		public string Phone { get; set; }

		[Display(Name = "Cellulare")]
		public string CellPhone { get; set; }

		[Display(Name = "Fax")]
		public string Fax { get; set; }

		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(Name = "Web")]
		[DataType(DataType.Url)]
		public string URL { get; set; }


	}

}
