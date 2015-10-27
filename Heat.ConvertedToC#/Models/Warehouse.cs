namespace Heat.Models
{
    /// <summary>
    /// Rappresenta un magazzino.
    /// </summary>
    /// <remarks></remarks>
    public class Warehouse
	{

		public int ID { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public bool HasValue { get; set; }
		public bool CheckStockBefore { get; set; }


	}

}
