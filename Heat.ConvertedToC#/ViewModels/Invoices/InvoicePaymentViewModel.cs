using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Invoices
{

    public class InvoicePaymentViewModel
	{

		[Key()]
		public int ID { get; set; }

		[Display(Name = "Cliente")]
		public string CustomerName { get; set; }

		[Display(Name = "Numero fattura provvisoria")]
		public string InvoiceNumber { get; set; }

		[Display(Name = "Data documento")]
		public string InvoiceDate { get; set; }

		public List<PresentationInvoiceRowViewModel> Rows { get; set; }
		//Property Rows As List(Of InvoiceRowViewModel)

		[Required()]
		[Display(Name = "Condizioni di pagamento")]
		public int PaymentID { get; set; }

		public IEnumerable<SelectListItem> PaymentList { get; set; }

		[Display(Name = "Fattura esente")]
		public bool IsTaxExempt { get; set; }

		[Display(Name = "Esenzione")]
		public string TaxExemption { get; set; }


	}

}
