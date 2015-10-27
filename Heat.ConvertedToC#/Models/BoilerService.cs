using System;
namespace Heat.Models
{

    /// <summary>
    /// Rappresenta una operazione di manutenzione di impianto per la caldaia.
    /// </summary>
    /// <remarks></remarks>
    public class BoilerService
	{

		public int ID { get; set; }
		public Boiler Boiler { get; set; }
		public BoilerServiceType Type { get; set; }

		/// <summary>
		/// Data della ultima manutenzione eseguita.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public DateTime PreviousServiceDate { get; set; }

		/// <summary>
		/// Periodicità della manutenzione.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public Periodicity Periodicity { get; set; }

		/// <summary>
		/// Scadenza legale della manutenzione.
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
