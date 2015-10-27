using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

		[Display(Name = "Codice impianto")]
		public int Code { get; set; }
		[Display(Name = "Nominativo")]
		public string Name { get; set; }

		[Display(Name = "Classe impianto")]
		public PlantClass PlantClass { get; set; }

		[Display(Name = "Tipologia impianto")]
		public PlantType PlantType { get; set; }

		[Display(Name = "Codice dell'impianto per la provincia")]
		public string PlantDistinctCode { get; set; }

		public PlantBuilding BuildingAddress { get; set; }

		public ThermalUnit ThermalUnit { get; set; }

		public List<Contact> Contacts { get; set; }

		public PlantService Service { get; set; }

		public List<Medium> Media { get; set; }

	}

}
