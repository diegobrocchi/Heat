using System.ComponentModel.DataAnnotations;

namespace Heat.Models
{

    public class WarehouseMovement
	{

		public int ID { get; set; }

		//EF by-configuration foreign key
		public int ProductID { get; set; }
		public Product Product { get; set; }

		public double Quantity { get; set; }
		[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public System.DateTime ExecDate { get; set; }
		public string Note { get; set; }

		public int SourceID { get; set; }
		public Warehouse Source { get; set; }

		public int DestinationID { get; set; }
		public Warehouse Destination { get; set; }

		public int CausalWarehouseID { get; set; }
		public CausalWarehouse CausalWarehouse { get; set; }

	}
}
