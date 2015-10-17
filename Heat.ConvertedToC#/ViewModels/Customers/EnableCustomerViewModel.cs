using System;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Customers
{
    public class EnableCustomerViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Cliente")]
		public string CustomerName { get; set; }

		[Display(Name = "Data di disabilitazione")]
		public DateTime? DisableDate { get; set; }

	}
}

