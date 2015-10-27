using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels
{
    public class CustomerViewModel
	{
		public int ID { get; set; }
		[Display(Name = "Nome")]
		public string Name { get; set; }

		[Display(Name = "Indirizzo")]
		public string Address { get; set; }

		[Display(Name = "Telefono")]
		public string Telephone { get; set; }
	}
}

