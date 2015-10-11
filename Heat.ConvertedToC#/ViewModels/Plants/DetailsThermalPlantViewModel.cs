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
	/// <summary>
	/// Oggetto con ottenuto con flattening parziale di Plant, Plant.BuildingAddress e Plant.ThermalUnit
	/// </summary>
	/// <remarks></remarks>
	public class DetailsThermalPlantViewModel
	{

		#region "Proprietà derivate da Plant"
		public int ID { get; set; }
		[Display(name = "Classe impianto")]
		public string PlantClass { get; set; }

		[Display(name = "Tipologia impianto")]
		public string PlantType { get; set; }


		#endregion

		#region "Proprietà derivate da Plant.BuidingAddress"
		[Display(name = "Singola unità abitativa")]
		public bool IsSingleUnit { get; set; }

		[Display(name = "Categoria energetica")]
		public EnergyCategoryEnum EnergyCategory { get; set; }

		[Display(name = "Volume lordo riscaldato (m³)")]
		public float GrossHeatedVolumeM3 { get; set; }

		[Display(name = "Volume lordo raffrescato (m³)")]
		public float GrossCooledVolumeM3 { get; set; }
		#endregion

		#region "Proprietà derivate da Plant.ThermalUnit"
		[Display(name = "Costruttore")]
		public string Manifacturer { get; set; }

		[Display(name = "Modello")]
		public string Model { get; set; }

		[Display(name = "Matricola")]
		public string SerialNumber { get; set; }

		[Display(name = "Data di installazione")]
		[DataType(DataType.Date)]
		[DisplayFormat(dataformatstring = "{0:d}")]
		public DateTime InstallationDate { get; set; }

		[Display(name = "Data di prima accensione")]
		[DataType(DataType.Date)]
		[DisplayFormat(dataformatstring = "{0:d}")]
		public Nullable<DateTime> FirstStartUp { get; set; }

		[Display(name = "Garanzia")]
		public string Warranty { get; set; }

		[Display(name = "Scadenza garanzia")]
		[DataType(DataType.Date)]
		[DisplayFormat(dataformatstring = "{0:d}")]
		public Nullable<DateTime> WarrantyExpiration { get; set; }

		[Display(name = "Combustibile")]
		public string Fuel { get; set; }

		[Display(name = "Potenza termica utile nominale Pn max (kW)")]
		public float NominalThermalPowerMax { get; set; }

		[Display(name = "Fluido termovettore")]
		public string HeatTransferFluid { get; set; }

		[Display(name = "Rendimento termico utile a Pn max (%)")]
		public float ThermalEfficiencyPowerMax { get; set; }

		[Display(name = "Tipo di unità termica")]
		public ThermalUnitKindEnum Kind { get; set; }

		//Property Heaters As List(Of Heater)
		#endregion

	}
}

