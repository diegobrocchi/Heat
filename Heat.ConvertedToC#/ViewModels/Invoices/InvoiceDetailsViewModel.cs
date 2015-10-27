using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Invoices
{
    public class InvoiceDetailsViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Cliente")]
		public string CustomerName { get; set; }

		[Display(Name = "Numero documento")]
		public string InvoiceNumber { get; set; }

		[Display(Name = "Data documento")]
		public string InvoiceDate { get; set; }

		//Property Rows As List(Of InvoiceRowViewModel)
		public List<PresentationInvoiceRowViewModel> Rows { get; set; }

		[Display(Name = "Condizioni di pagamento")]
		public string Payment { get; set; }

		[Display(Name = "Fattura esente")]
		public bool IsTaxExempt { get; set; }

		[Display(Name = "Esenzione")]
		public string TaxExemption { get; set; }
	}

}
