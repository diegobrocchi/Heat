namespace Heat.Models
{

    public class Numbering
	{

		public int ID { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public int TempSerialSchemaID { get; set; }
		public virtual SerialScheme TempSerialSchema { get; set; }
		public int FinalSerialSchemaID { get; set; }
		public virtual SerialScheme FinalSerialSchema { get; set; }
		public SerialNumber LastTempSerial { get; set; }
		public SerialNumber LastFinalSerial { get; set; }

	}
}
