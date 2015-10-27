using System;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.PlantServices
{
    public class CreatePlantServiceViewModel
	{

		public int PlantID { get; set; }

		[Display(Name = "Impianto di riferimento")]
		public string PlantDescription { get; set; }

		[Display(Name = "Data dell'ultima manutenzione eseguita")]
		public Nullable<DateTime> PreviousServiceDate { get; set; }

		[Display(Name = "Periodicità della manutenzione")]
		public Periodicity Periodicity { get; set; }

		[Display(Name = "Scadenza legale della manutenzione")]
		public DateTime LegalExpirationDate { get; set; }

		[Display(Name = "Data programmata della prossima manutenzione")]
		public DateTime PlannedServiceDate { get; set; }

	}
}

