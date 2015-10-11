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

		[Display(name = "Nominativo")]
		public string Name { get; set; }

		[Display(name = "Codice dell'impianto per la provincia")]
		public string PlantDistinctCode { get; set; }

		[Display(name = "Indirizzo")]
		public string Address { get; set; }

		[Display(name = "Numero Civico")]
		public string StreetNumber { get; set; }

		[Display(name = "Palazzo")]
		public string Building { get; set; }

		[Display(name = "Scala")]
		public string Stair { get; set; }

		[Display(name = "Interno")]
		public string Apartment { get; set; }

		[Display(name = "Località")]
		public string City { get; set; }

		[Display(name = "CAP")]
		public string PostalCode { get; set; }

		[Display(name = "Area")]
		public string Area { get; set; }

		[Display(name = "Zona")]
		public string Zone { get; set; }

		[Display(name = "Provincia")]
		public string District { get; set; }

	}

}
