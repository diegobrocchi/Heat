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
using System.ComponentModel.DataAnnotations.Schema;

namespace Heat.Models
{
	/// <summary>
	/// Rappresenta un Impianto: un impianto ha un libretto di impianto.
	/// </summary>
	/// <remarks></remarks>
	public class Plant
	{

		public Plant()
		{
			this.Contacts = new List<Contact>();
			this.Media = new List<Medium>();
		}

		[Key()]
		public int ID { get; set; }

		[Display(name = "Codice impianto")]
		public int Code { get; set; }
		[Display(name = "Nominativo")]
		public string Name { get; set; }

		[Display(name = "Classe impianto")]
		public PlantClass PlantClass { get; set; }

		[Display(name = "Tipologia impianto")]
		public PlantType PlantType { get; set; }

		[Display(name = "Codice dell'impianto per la provincia")]
		public string PlantDistinctCode { get; set; }

		public PlantBuilding BuildingAddress { get; set; }

		public ThermalUnit ThermalUnit { get; set; }

		public List<Contact> Contacts { get; set; }

		public PlantService Service { get; set; }

		public List<Medium> Media { get; set; }

	}

}
