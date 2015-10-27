using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Plants
{
    public class IndexPlantViewModel
	{
		public int ID { get; set; }

		[Display(Name = "Nominativo")]
		public string Name { get; set; }

		[Display(Name = "Classe impianto")]
		public string PlantClass { get; set; }

		[Display(Name = "Tipologia impianto")]
		public string PlantType { get; set; }

		[Display(Name = "Codice dell'impianto per la provincia")]
		public string PlantDistinctCode { get; set; }

		[Display(Name = "Indirizzo")]
		public string Address { get; set; }



	}

}
