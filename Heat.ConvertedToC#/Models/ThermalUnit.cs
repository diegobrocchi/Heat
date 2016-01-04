using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Heat.Models
{

    /// <summary>
    /// Rappresenta un generatore di calore: gruppo termico (quindi con bruciatore integerato) oppure caldaia.
    /// </summary>
    /// <remarks></remarks>
    public class ThermalUnit
	{
		[Key()]
		public int ID { get; set; }

		//************
		//Proprietà copiate da Futura
		public int ManifacturerId { get; set; }
		public Manifacturer Manifacturer { get; set; }
		public int ModelID { get; set; }
		public ManifacturerModel Model { get; set; }
		public string SerialNumber { get; set; }
		public Nullable<DateTime> InstallationDate { get; set; }
		public Nullable<DateTime> FirstStartUp { get; set; }
		public string Warranty { get; set; }
		public Nullable<DateTime> WarrantyExpiration { get; set; }
		//Fine proprietà copiate da Futura

		//************
		//Proprietà del libretto di impianto
		public int FuelID { get; set; }
		public Fuel Fuel { get; set; }

		//Potenza termica utile nominale Pn max (kW)
		public float NominalThermalPowerMax { get; set; }

		public Nullable<DateTime> DismissDate { get; set; }

		public int HeatTransferFluidID { get; set; }
		public HeatTransferFluid HeatTransferFluid { get; set; }
		//Rendimento termico utile a Pn max (%)
		public float ThermalEfficiencyPowerMax { get; set; }

		//Esiste anche una classe 'ThermalUnitKind': da decidere cosa è meglio, se enum o classe.
		public ThermalUnitKindEnum Kind { get; set; }

		public List<Heater> Heaters { get; set; }

		//**************
		//fine proprietà del libretto di impianto



	}
}

