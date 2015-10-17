using System;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Invoices
{
    /// <summary>
    /// Un modello per la visualizzazione della griglia delle fatture confermate. 
    /// </summary>
    /// <remarks></remarks>
    public class confirmedInvoicesGridViewModel
	{
		public int ID { get; set; }

		[Display(Name = "Cliente")]
		public string Customer { get; set; }

		[Display(Name = "Data emissione")]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime InvoiceDate { get; set; }

		[Display(Name = "Numero")]
		public string InvoiceNumber { get; set; }

		[Display(Name = "TOTALE")]
		public decimal TotalAmount { get; set; }

		[Display(Name = "IVA")]
		public decimal TaxesAmount { get; set; }

		[Display(Name = "Imponibile")]
		public decimal TaxableAmount { get; set; }

		[Display(Name = "Pagamento")]
		public string Payment { get; set; }


	}
}

