using System.ComponentModel.DataAnnotations;


namespace Heat.ViewModels.Invoices
{
    public class InvoiceRowViewModel
	{

		[Key()]
		public int ID { get; set; }

		public int InvoiceID { get; set; }

		[Display(Name = "Item")]
		public int Item { get; set; }

		[Display(Name = "Prodotto")]
		public string Product { get; set; }

		[Display(Name = "Quantità")]
		public float Quantity { get; set; }

		[Display(Name = "Prezzo")]
		public decimal UnitPrice { get; set; }

		[Display(Name = "IVA")]
		public float VAT { get; set; }

		[Display(Name = "Sconto 1")]
		public float Discount1 { get; set; }

		[Display(Name = "Sconto 2")]
		public float Discount2 { get; set; }

		[Display(Name = "Sconto 3")]
		public float Discount3 { get; set; }

		[Display(Name = "Totale imponibile")]
		public decimal TotalBeforeTax { get; set; }

		[Display(Name = "TOTALE")]
		public decimal Total { get; set; }


	}

}
