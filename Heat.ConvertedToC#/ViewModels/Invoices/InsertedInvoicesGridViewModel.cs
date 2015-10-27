using System;
using System.ComponentModel.DataAnnotations;


namespace Heat.ViewModels.Invoices
{
    /// <summary>
    /// Modello per la visualizzazione della griglia delle fatture inserite (ma non confermate).
    /// </summary>
    /// <remarks></remarks>
    public class InsertedInvoicesGridViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Cliente")]
		public string Customer { get; set; }

		[Display(Name = "Data emissione")]
		[DisplayFormat(DataFormatString = "{0: d}")]
		public DateTime InvoiceDate { get; set; }

		[Display(Name = "Numero Provvisorio")]
		public string InvoiceNumber { get; set; }

		[Display(Name = "Numero righe")]
		public int RowCount { get; set; }

	}

}
