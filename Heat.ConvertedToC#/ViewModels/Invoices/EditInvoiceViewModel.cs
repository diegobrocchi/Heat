using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Invoices
{
    public class EditInvoiceViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Cliente")]
		public string CustomerName { get; set; }

		[Display(Name = "Numero documento")]
		public string InvoiceNumber { get; set; }

		[Display(Name = "Data documento")]
		public string InvoiceDate { get; set; }

		public List<PresentationInvoiceRowViewModel> Rows { get; set; }


	}
}

