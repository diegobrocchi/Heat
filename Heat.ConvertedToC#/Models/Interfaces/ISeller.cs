namespace Heat.Models
{
    /// <summary>
    /// Un ente che può emettere una fattura
    /// </summary>
    /// <remarks></remarks>
    public interface ISeller
	{
		/// <summary>
		/// Identificativo univoco 
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		int ID { get; set; }
		/// <summary>
		/// Nome o ragione sociale
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		string Name { get; set; }
		/// <summary>
		/// Indirizzo della sede legale
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		Address Address { get; set; }
		/// <summary>
		/// Numero di Partita IVA
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		string Vat_Number { get; set; }
		/// <summary>
		/// Codice fiscale
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		string FiscalCode { get; set; }
		/// <summary>
		/// Codice IBAN 
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		string IBAN { get; set; }
		/// <summary>
		/// Percorso del file del logo
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		string Logo { get; set; }
	}

}
