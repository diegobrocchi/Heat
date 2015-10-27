namespace Heat.Models
{
    /// <summary>
    /// Rappresenta un bruciatore della caldaia; può essere l'unico bruciatore o uno dei tanti bruciatori.
    /// </summary>
    /// <remarks></remarks>
    public class BoilerHeater
	{
		public int ID { get; set; }
		public Boiler Boiler { get; set; }
		public Manifacturer Manifacturer { get; set; }
		public ManifacturerModel Model { get; set; }
		public string SerialNumber { get; set; }
		public float MinimumPowerKW { get; set; }
		public float MaximumPowerKW { get; set; }
		public string CertificationReference { get; set; }

	}
}
