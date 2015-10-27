using System.Collections.Generic;
namespace Heat.Models
{

    public class Invoice
	{

		public int ID { get; set; }
		/// <summary>
		/// Numero di serie del documento non appena viene inserito
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public SerialNumber InsertedNumber { get; set; }

		/// <summary>
		/// Numero di serie del documento quando viene confermato
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public SerialNumber ConfirmedNumber { get; set; }
		/// <summary>
		/// Stato del documento: Inserted, Confirmed o Deleted.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public DocumentState State { get; set; }
		/// <summary>
		/// Ente emittente del documento
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public ISeller Seller { get; set; }
		/// <summary>
		/// Soggetto verso cui è emesso il documento.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public Customer Customer { get; set; }
		/// <summary>
		/// Data del documento.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public System.DateTime InvoiceDate { get; set; }
		/// <summary>
		/// Importo IMPONIBILE totale della fattura: calcolato al momento della conferma del documento come somma dell'IMPONIBILE di ogni riga.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public decimal TaxableAmount { get; set; }
		public decimal TaxRate { get; set; }
		/// <summary>
		/// Importo totale dell'IVA del documento: calcolato al momento della conferma del documento come somma dell'IVA di ogni riga.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public decimal TaxesAmount { get; set; }
		/// <summary>
		/// Importo totale del documento: calcolato al momento della conferma del documento.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public decimal TotalAmount { get; set; }
		public bool SelfBilling { get; set; }
		public bool IsTaxExempt { get; set; }
		public string TaxExemption { get; set; }
		public Payment Payment { get; set; }

		public List<InvoiceRow> InvoiceRows { get; set; }

	}
}
