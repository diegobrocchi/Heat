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
		[Display(Name = "Classe impianto")]
		public string PlantClass { get; set; }

		[Display(Name = "Tipologia impianto")]
		public string PlantType { get; set; }


		#endregion

		#region "Proprietà derivate da Plant.BuidingAddress"
		[Display(Name = "Singola unità abitativa")]
		public bool IsSingleUnit { get; set; }

		[Display(Name = "Categoria energetica")]
		public EnergyCategoryEnum EnergyCategory { get; set; }

		[Display(Name = "Volume lordo riscaldato (m³)")]
		public float GrossHeatedVolumeM3 { get; set; }

		[Display(Name = "Volume lordo raffrescato (m³)")]
		public float GrossCooledVolumeM3 { get; set; }
		#endregion

		#region "Proprietà derivate da Plant.ThermalUnit"
		[Display(Name = "Costruttore")]
		public string Manifacturer { get; set; }

		[Display(Name = "Modello")]
		public string Model { get; set; }

		[Display(Name = "Matricola")]
		public string SerialNumber { get; set; }

		[Display(Name = "Data di installazione")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime InstallationDate { get; set; }

		[Display(Name = "Data di prima accensione")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public Nullable<DateTime> FirstStartUp { get; set; }

		[Display(Name = "Garanzia")]
		public string Warranty { get; set; }

		[Display(Name = "Scadenza garanzia")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public Nullable<DateTime> WarrantyExpiration { get; set; }

		[Display(Name = "Combustibile")]
		public string Fuel { get; set; }

		[Display(Name = "Potenza termica utile nominale Pn max (kW)")]
		public float NominalThermalPowerMax { get; set; }

		[Display(Name = "Fluido termovettore")]
		public string HeatTransferFluid { get; set; }

		[Display(Name = "Rendimento termico utile a Pn max (%)")]
		public float ThermalEfficiencyPowerMax { get; set; }

		[Display(Name = "Tipo di unità termica")]
		public ThermalUnitKindEnum Kind { get; set; }

		//Property Heaters As List(Of Heater)
		#endregion

	}
}

