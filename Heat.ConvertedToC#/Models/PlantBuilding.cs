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

namespace Heat.Models
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks></remarks>
	public class PlantBuilding
	{

		[Display(name = "Indirizzo")]
		public string Address { get; set; }

		[Display(name = "Numero Civico")]
		public string StreetNumber { get; set; }

		[Display(name = "Palazzo")]
		public string Building { get; set; }

		[Display(name = "Scala")]
		public string Stair { get; set; }

		[Display(name = "Interno")]
		public string Apartment { get; set; }

		[Display(name = "Località")]
		public string City { get; set; }

		[Display(name = "CAP")]
		public string PostalCode { get; set; }

		[Display(name = "Area")]
		public string Area { get; set; }

		[Display(name = "Zona")]
		public string Zone { get; set; }

		[Display(name = "Provincia")]
		public string District { get; set; }

		//*************
		//forse queste proprietà non dovrebbero stare qui, ma nel Plant
		//sono qui perchè il Libretto di Impianto le mette nel 'Ubicazione e destinazione dell'edificio'
		[Display(name = "Singola unità abitativa")]
		public bool IsSingleUnit { get; set; }

		[Display(name = "Categoria energetica")]
		public EnergyCategoryEnum EnergyCategory { get; set; }

		[Display(name = "Volume lordo riscaldato (m³)")]
		public float GrossHeatedVolumeM3 { get; set; }

		[Display(name = "Volume lordo raffrescato (m³)")]
		public float GrossCooledVolumeM3 { get; set; }

	}
}
