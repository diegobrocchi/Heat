using System.ComponentModel.DataAnnotations;

namespace Heat.Models
{
    /// <summary>
    /// Rappresenta il tipo di indirizzo (Fatturazione, domicilio, generico...)
    /// </summary>
    public class AddressType
	{
		[Key()]
		public int ID { get; set; }
		public string Description { get; set; }

	}
}
