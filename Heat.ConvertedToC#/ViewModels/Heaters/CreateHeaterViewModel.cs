using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Heaters
{
    public class CreateHeaterViewModel
	{

		public int ThermalUnitID { get; set; }
		[Display(Name = "Generatore di riferimento")]
		public string ThermalUnitDescription { get; set; }

		[Display(Name = "Marca")]
		public string ManifacturerID { get; set; }
		public IEnumerable<SelectListItem> ManifacturerList { get; set; }

		[Display(Name = "Modello")]
		public int ModelID { get; set; }
		public IEnumerable<SelectListItem> ModelList { get; set; }

		[Display(Name = "Matricola")]
		public string SerialNumber { get; set; }

		[Display(Name = "Portata termica minima nominale (kW)")]
		public float MinimumPowerKW { get; set; }

		[Display(Name = "Portata termica massima nominale (kW)")]
		public float MaximumPowerKW { get; set; }

		[Display(Name = "Tipologia")]
		public string Type { get; set; }

		[Display(Name = "Data di installazione")]
		public DateTime InstallationDate { get; set; }

		[Display(Name = "Data di dismissione")]
		public Nullable<DateTime> DismissDate { get; set; }

		[Display(Name = "Combustibile")]
		public int FuelID { get; set; }
		public IEnumerable<SelectListItem> FuelList { get; set; }


	}

}
