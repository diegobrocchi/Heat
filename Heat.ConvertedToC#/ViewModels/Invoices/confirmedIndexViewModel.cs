using System.Collections.Generic;
using Heat.Models;

namespace Heat.ViewModels.Invoices
{
    /// <summary>
    /// Modello per la visualizzazione dell'elenco delle fatture in stato CONFERMATO.
    /// </summary>
    /// <remarks></remarks>
    public class confirmedIndexViewModel
	{
		/// <summary>
		/// Stato dei documenti.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public DocumentState State { get; set; }

		/// <summary>
		/// Conteggio delle fatture in stato INSERITO.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public int InsertedInvoiceCount { get; set; }

		/// <summary>
		/// Lista delle fatture CONFERMATE.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public List<confirmedInvoicesGridViewModel> ConfirmedInvoiceList { get; set; }

	}
}

