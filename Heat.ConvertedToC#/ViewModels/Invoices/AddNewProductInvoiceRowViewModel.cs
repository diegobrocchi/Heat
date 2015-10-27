using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Invoices
{

    public class AddNewProductInvoiceRowViewModel
	{
		public int InvoiceID { get; set; }

		[Required()]
		[Display(Name = "Prodotto")]
		public int ProductID { get; set; }
		public IEnumerable<SelectListItem> ProductList { get; set; }

		[Required()]
		[Display(Name = "Quantità")]
		[Range(0, int.MaxValue)]
		public float Quantity { get; set; }

		[Display(Name = "Prezzo")]
		[DataType(DataType.Currency)]
		public decimal UnitPrice { get; set; }

		[Display(Name = "IVA")]
		public float VAT { get; set; }

		[Display(Name = "Sconto 1")]
		public float Discount1 { get; set; }

		[Display(Name = "Sconto 2")]
		public float Discount2 { get; set; }

		[Display(Name = "Sconto 3")]
		public float Discount3 { get; set; }


	}
}

