using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Invoices
{
    public class AddNewDescriptiveInvoiceRowViewModel
	{
		public int InvoiceID { get; set; }

		[Required()]
		[Display(Name = "Descrizione")]
		[DataType(DataType.MultilineText)]
		public string RowDescription { get; set; }

		[Required()]
		[Display(Name = "Quantità")]
		[Range(0, int.MaxValue)]
		public float Quantity { get; set; }

		[Display(Name = "Prezzo")]
		[DataType(DataType.Currency)]
		public decimal UnitPrice { get; set; }

		[Display(Name = "IVA")]
		public double VAT { get; set; }

		[Display(Name = "Sconto 1")]
		public float Discount1 { get; set; }

		[Display(Name = "Sconto 2")]
		public float Discount2 { get; set; }

		[Display(Name = "Sconto 3")]
		public float Discount3 { get; set; }


	}
}

