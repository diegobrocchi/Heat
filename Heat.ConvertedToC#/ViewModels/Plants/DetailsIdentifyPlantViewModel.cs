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

namespace Heat.ViewModels.Plants
{

	public class DetailsIdentifyPlantViewModel
	{

		public int ID { get; set; }

		[Display(Name = "Nominativo")]
		public string Name { get; set; }

		[Display(Name = "Codice dell'impianto per la provincia")]
		public string PlantDistinctCode { get; set; }

		[Display(Name = "Indirizzo")]
		public string Address { get; set; }

		[Display(Name = "Numero Civico")]
		public string StreetNumber { get; set; }

		[Display(Name = "Palazzo")]
		public string Building { get; set; }

		[Display(Name = "Scala")]
		public string Stair { get; set; }

		[Display(Name = "Interno")]
		public string Apartment { get; set; }

		[Display(Name = "Località")]
		public string City { get; set; }

		[Display(Name = "CAP")]
		public string PostalCode { get; set; }

		[Display(Name = "Area")]
		public string Area { get; set; }

		[Display(Name = "Zona")]
		public string Zone { get; set; }

		[Display(Name = "Provincia")]
		public string District { get; set; }

	}

}
