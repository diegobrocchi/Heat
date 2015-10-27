using System.Collections.Generic;
namespace Heat.Models
{

    /// <summary>
    /// Rappresenta un Modello di caldaia per il Produttore
    /// </summary>
    /// <remarks></remarks>
    public class ManifacturerModel
	{
		public int ID { get; set; }
		public int ManifacturerID { get; set; }
		public Manifacturer Manifacturer { get; set; }
		public string Model { get; set; }
		public List<BoilerService> Services { get; set; }

	}
}
