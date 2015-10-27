using System.ComponentModel.DataAnnotations;

namespace Heat.Models
{

    public class AddressType
	{

		[Key()]
		public int ID { get; set; }
		public string Description { get; set; }

	}
}
