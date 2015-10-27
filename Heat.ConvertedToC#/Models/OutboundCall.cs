using System;
namespace Heat.Models
{
    /// <summary>
    /// Rappresenta una chiamata ad un contatto per fissare un appuntamento.
    /// </summary>
    public class OutboundCall
	{
		public int ID { get; set; }
		public DateTime CallDate { get; set; }
		public int ContactID { get; set; }
		public virtual Contact Contact { get; set; }
		public int ResultID { get; set; }

		/// <summary>
		/// Chi ha eseguito la chiamata
		/// </summary>
		/// <returns></returns>
		public string Login { get; set; }
	}
}
