using System;
using System.Collections.Generic;
namespace Heat.Models
{
    /// <summary>
    /// Rappresenta una caldaia
    /// </summary>
    /// <remarks></remarks>
    public class Boiler
	{
		public int ID { get; set; }
		public Manifacturer Manifacturer { get; set; }
		public ManifacturerModel Model { get; set; }
		public string SerialNumber { get; set; }
		public DateTime InstallationDate { get; set; }
		public DateTime FirstStartUp { get; set; }
		public string Warranty { get; set; }
		public DateTime WarrantyExpiration { get; set; }

		/// <summary>
		/// Elenco delle operazioni di manutenzione eseguite sulla caldaia. 
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public List<BoilerService> Services { get; set; }

	}
}
