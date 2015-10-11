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

namespace Heat.ViewModels.Heaters
{
	public class CreateHeaterViewModel
	{

		public int ThermalUnitID { get; set; }
		[Display(name = "Generatore di riferimento")]
		public string ThermalUnitDescription { get; set; }

		[Display(name = "Marca")]
		public string ManifacturerID { get; set; }
		public IEnumerable<SelectListItem> ManifacturerList { get; set; }

		[Display(name = "Modello")]
		public int ModelID { get; set; }
		public IEnumerable<SelectListItem> ModelList { get; set; }

		[Display(name = "Matricola")]
		public string SerialNumber { get; set; }

		[Display(name = "Portata termica minima nominale (kW)")]
		public float MinimumPowerKW { get; set; }

		[Display(name = "Portata termica massima nominale (kW)")]
		public float MaximumPowerKW { get; set; }

		[Display(name = "Tipologia")]
		public string Type { get; set; }

		[Display(name = "Data di installazione")]
		public DateTime InstallationDate { get; set; }

		[Display(name = "Data di dismissione")]
		public Nullable<DateTime> DismissDate { get; set; }

		[Display(name = "Combustibile")]
		public int FuelID { get; set; }
		public IEnumerable<SelectListItem> FuelList { get; set; }


	}

}
