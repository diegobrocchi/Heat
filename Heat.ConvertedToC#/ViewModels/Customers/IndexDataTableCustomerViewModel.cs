namespace Heat.ViewModels.Customers
{
    /// <summary>
    /// Il modello che viene mostrato nel jQuery Datatable.
    /// E' un subset di Customer e ha solo le proprietà che interessa mostrare.
    /// </summary>
    /// <remarks></remarks>
    public class IndexDataTableCustomerViewModel
	{
		/// <summary>
		/// Chiave primaria del Customer
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public int ID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Telephone1 { get; set; }
		public bool IsEnabled { get; set; }


	}
}



