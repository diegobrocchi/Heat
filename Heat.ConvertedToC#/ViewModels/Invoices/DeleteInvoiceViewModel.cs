using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Invoices
{
    public class DeleteInvoiceViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Numero")]
		public string InvoiceNumber { get; set; }

		[Display(Name = "Cliente")]
		public string CustomerName { get; set; }

		[Display(Name = "Data documento")]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime InvoiceDate { get; set; }

		public List<PresentationInvoiceRowViewModel> Rows { get; set; }
		// Property Rows As List(Of InvoiceRowViewModel)

	}
}

