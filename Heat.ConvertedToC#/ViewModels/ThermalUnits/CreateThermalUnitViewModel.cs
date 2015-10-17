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

namespace Heat.ViewModels.ThermalUnits
{
	public class CreateThermalUnitViewModel
	{

		public int PlantID { get; set; }
		[Display(Name = "Impianto")]
		public string PlantDescription { get; set; }
		public IEnumerable<SelectListItem> PlantList { get; set; }

		public bool PlantIDSelected { get; set; }

		[Display(Name = "Marca")]
		public string ManifacturerID { get; set; }
		public IEnumerable<SelectListItem> ManifacturerList { get; set; }

		[Display(Name = "Modello")]
		public int ModelID { get; set; }
		public IEnumerable<SelectListItem> ModelList { get; set; }

		[Display(Name = "Matricola")]
		public string SerialNumber { get; set; }

		[Display(Name = "Data di installazione")]
		[DataType(DataType.Date)]
		public DateTime InstallationDate { get; set; }

		[Display(Name = "Data di prima accensione")]
		[DataType(DataType.Date)]
		public Nullable<DateTime> FirstStartUp { get; set; }

		[Display(Name = "Garanzia")]
		public string Warranty { get; set; }

		[Display(Name = "Scadenza garanzia")]
		[DataType(DataType.Date)]
		public Nullable<DateTime> WarrantyExpiration { get; set; }

		[Required()]
		[Display(Name = "Combustibile")]
		public int FuelID { get; set; }
		public IEnumerable<SelectListItem> FuelList { get; set; }

		[Display(Name = "Potenza termica utile nominale Pn max (kW)")]
		public float NominalThermalPowerMax { get; set; }

		[Display(Name = "Fluido termovettore")]
		public int HeatTransferFluidID { get; set; }
		public IEnumerable<SelectListItem> HeatTransferFluidList { get; set; }

		[Display(Name = "Rendimento termico utile a Pn max (%)")]
		public float ThermalEfficiencyPowerMax { get; set; }

		[Required()]
		[Display(Name = "Tipo di unità")]
		public ThermalUnitKindEnum Kind { get; set; }



	}
}

