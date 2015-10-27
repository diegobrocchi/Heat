using System.ComponentModel.DataAnnotations;

namespace Heat.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class PlantBuilding
	{

		[Display(Name = "Indirizzo")]
		public string Address { get; set; }

		[Display(Name = "Numero Civico")]
		public string StreetNumber { get; set; }

		[Display(Name = "Palazzo")]
		public string Building { get; set; }

		[Display(Name = "Scala")]
		public string Stair { get; set; }

		[Display(Name = "Interno")]
		public string Apartment { get; set; }

		[Display(Name = "Località")]
		public string City { get; set; }

		[Display(Name = "CAP")]
		public string PostalCode { get; set; }

		[Display(Name = "Area")]
		public string Area { get; set; }

		[Display(Name = "Zona")]
		public string Zone { get; set; }

		[Display(Name = "Provincia")]
		public string District { get; set; }

		//*************
		//forse queste proprietà non dovrebbero stare qui, ma nel Plant
		//sono qui perchè il Libretto di Impianto le mette nel 'Ubicazione e destinazione dell'edificio'
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
