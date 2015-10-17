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

		[Display(Name = "Indirizzo")]
		public string Address { get; set; }

		[Display(Name = "Numero Civico")]
		public string StreetNumber { get; set; }

		[Display(Name = "Palazzo")]
		public string Building { get; set; }

		[Display(Name = "Scala")]
		public string Stair { get; set; }

		[Display(Name = "Interno")]
		public string Apartment { get; set; }

		[Display(Name = "Località")]
		public string City { get; set; }

		[Display(Name = "CAP")]
		public string PostalCode { get; set; }

		[Display(Name = "Area")]
		public string Area { get; set; }

		[Display(Name = "Zona")]
		public string Zone { get; set; }

		[Display(Name = "Provincia")]
		public string District { get; set; }

		//*************
		//forse queste proprietà non dovrebbero stare qui, ma nel Plant
		//sono qui perchè il Libretto di Impianto le mette nel 'Ubicazione e destinazione dell'edificio'
		[Display(Name = "Singola unità abitativa")]
		public bool IsSingleUnit { get; set; }

		[Display(Name = "Categoria energetica")]
		public EnergyCategoryEnum EnergyCategory { get; set; }

		[Display(Name = "Volume lordo riscaldato (m³)")]
		public float GrossHeatedVolumeM3 { get; set; }

		[Display(Name = "Volume lordo raffrescato (m³)")]
		public float GrossCooledVolumeM3 { get; set; }

	}
}
