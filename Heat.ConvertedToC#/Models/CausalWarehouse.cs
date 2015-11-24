namespace Heat.Models
{
    /// <summary>
    /// Rappresenta una causale di movimento di magazzino.
    /// </summary>
    /// <remarks></remarks>
    public class CausalWarehouse
	{
		public int ID { get; set; }
		public string Code { get; set; }
		public int Sign { get; set; }

		public int TypeID { get; set; }
		public CausalWarehouseTypeEnum Type { get; set; }
		public bool Transaction { get; set; }

	}
}
