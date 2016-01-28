using System;

namespace Heat.Models
{

    /// <summary>
    /// Rappresenta un bruciatore della caldaia; può essere l'unico bruciatore o uno dei tanti bruciatori.
    /// </summary>
    /// <remarks></remarks>
    public class Heater
	{

		public int ID { get; set; }
		public ThermalUnit ThermalUnit { get; set; }

		public Manifacturer Manifacturer { get; set; }
		public ManifacturerModel Model { get; set; }
		public string SerialNumber { get; set; }

		public float MinimumPowerKW { get; set; }
		public float MaximumPowerKW { get; set; }

		public DateTime? InstallationDate { get; set; }
		public string Type { get; set; }

		public int FuelID { get; set; }
		public Fuel Fuel { get; set; }

		public Nullable<DateTime> DismissDate { get; set; }

	}
}

