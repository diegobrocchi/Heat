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

namespace Heat.ViewModels.Plants
{
	public class AddThermInfoPlantViewModel
	{

		public int PlantID { get; set; }

		[Display(Name = "Classe impianto")]
		public int PlantClassID { get; set; }
		public IEnumerable<SelectListItem> PlantClassList { get; set; }

		[Display(Name = "Tipologia impianto")]
		public int PlantTypeID { get; set; }
		public IEnumerable<SelectListItem> PlantTypeList { get; set; }


		[Display(Name = "Codice dell'impianto per la provincia")]
		public string PlantDistinctCode { get; set; }


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

