using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Plants
{
    public class AddThermInfoPlantViewModel
	{

		public int PlantID { get; set; }

		[Display(Name = "Classe impianto")]
		public int PlantClassID { get; set; }
		public IEnumerable<SelectListItem> PlantClassList { get; set; }

		[Display(Name = "Tipologia impianto")]
		public int PlantTypeID { get; set; }
		public IEnumerable<SelectListItem> PlantTypeList { get; set; }


		[Display(Name = "Codice dell'impianto per la provincia")]
		public string PlantDistinctCode { get; set; }


		[Display(Name = "Singola unità abitativa")]
		public bool IsSingleUnit { get; set; }

		[Display(Name = "Categoria energetica")]
		public EnergyCategoryEnum EnergyCategory { get; set; }

		[Display(Name = "Volume lordo riscaldato (m³)")]
		public float GrossHeatedVolumeM3 { get; set; }

		[Display(Name = "Volume lordo raffrescato (m³)")]
		public float GrossCooledVolumeM3 { get; set; }
	}
}

