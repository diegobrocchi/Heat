using System;

namespace Heat.Models
{
    /// <summary>
    /// Rappresenta la situazione della manutenzione per l'impianto. E' la rappresentazione dello stato di manutenzione. 
    /// Esiste un solo PlantService per un Plant. 1 Plant ha 0 o 1 PlantService.
    /// </summary>
    /// <remarks></remarks>
    public class PlantService
	{


		public int ID { get; set; }

		/// <summary>
		/// Data della ultima manutenzione eseguita.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public Nullable<DateTime> PreviousServiceDate { get; set; }

		/// <summary>
		/// Periodicità della manutenzione.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public Periodicity Periodicity { get; set; }

		/// <summary>
		/// Scadenza legale della manutenzione.
		/// Calcolata in base alla periodicità.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public DateTime LegalExpirationDate { get; set; }

		/// <summary>
		/// Data programmata di esecuzione della manutenzione.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public DateTime PlannedServiceDate { get; set; }

	}
}

