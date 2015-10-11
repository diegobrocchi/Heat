using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
		public DateTime InstallationDate { get; set; }
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

