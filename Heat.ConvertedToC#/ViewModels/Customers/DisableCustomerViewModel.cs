using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Customers
{
    public class DisableCustomerViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Cliente")]
		public string CustomerName { get; set; }


	}
}

