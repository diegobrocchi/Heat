using System.Collections.Generic;
namespace Heat.Models
{

    /// <summary>
    /// Rappresenta una chiamata per il rinnovo di una manutenzione in scadenza
    /// </summary>
    public class ProposedOutBoundCall
	{
       
		public int ID { get; set; }
		/// <summary>
		/// L'utente Heat a cui è stata proposta la chiamata.
		/// </summary>
		/// <returns></returns>
		public string User { get; set; }
		public int PlantID { get; set; }
		public Plant Plant { get; set; }
		//public virtual List<Contact> Contacts { get; set; }

	}
}
