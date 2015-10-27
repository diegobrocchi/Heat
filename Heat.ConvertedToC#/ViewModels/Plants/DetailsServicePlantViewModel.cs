using System;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Plants
{

    public class DetailsServicePlantViewModel
	{

		public int ID { get; set; }

		public int PlantID { get; set; }


		[Display(Name = "Data ultima manutenzione eseguita")]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public Nullable<DateTime> PreviousServiceDate { get; set; }

		[Display(Name = "Periodicità")]
		public Periodicity Periodicity { get; set; }

		[Display(Name = "Scadenza")]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime LegalExpirationDate { get; set; }

		[Display(Name = "Data programmata della manutenzione")]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime PlannedServiceDate { get; set; }
	}
}
