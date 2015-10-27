namespace Heat.Models
{

    public class Product
	{

		public int ID { get; set; }
		public string SKU { get; set; }
		public string Description { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Cost { get; set; }
		public int ReorderLevel { get; set; }


	}
}
