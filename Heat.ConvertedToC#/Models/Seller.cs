namespace Heat.Models
{
    /// <summary>
    /// Rappresenta un ente in grado di emettere una fattura
    /// </summary>
    /// <remarks></remarks>
    public class Seller : ISeller
	{

		public Address Address { get; set; }

		public string FiscalCode { get; set; }

		public string IBAN { get; set; }

		public int ID { get; set; }

		public string Logo { get; set; }

		public string Name { get; set; }

		public string Vat_Number { get; set; }
	}
}

