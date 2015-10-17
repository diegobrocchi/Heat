using System.ComponentModel.DataAnnotations;

namespace Heat.Models
{

    public class Address
	{
		[Key()]
		public int ID { get; set; }
		public int AddressTypeID { get; set; }
		public AddressType AddressType { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string District { get; set; }
		public string State { get; set; }
		public string Note { get; set; }

		//Property CustomerID As Nullable(Of Integer)
		//Overridable Property Customer As Customer


	}
}
