using System;
namespace Heat.Models
{

    public abstract class Document
	{
		public int ID { get; set; }

		public int TemporaryNumber { get; set; }
		public string TemporaryStringNumber { get; set; }
		public int Number { get; set; }
		public string StringNumber { get; set; }
		public Customer Customer { get; set; }
		public DateTime PrintDate { get; set; }
		public Numbering Numerator { get; set; }
		public HeatUser CreateUser { get; set; }
		public DateTime CreationDate { get; set; }
		public HeatUser LastModifyUser { get; set; }
		public DateTime LastModifyDate { get; set; }
		public DocumentState State { get; set; }
	}

	public enum DocumentState
	{
		Inserted = 0,
		Confirmed = 1,
		Deleted = 3

	}
}

