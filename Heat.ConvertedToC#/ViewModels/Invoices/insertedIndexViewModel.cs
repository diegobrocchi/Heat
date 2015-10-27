using System.Collections.Generic;
using Heat.Models;

namespace Heat.ViewModels.Invoices
{
    public class insertedIndexViewModel
	{
		public DocumentState State { get; set; }
		public List<InsertedInvoicesGridViewModel> InsertedInvoiceList { get; set; }

	}
}

