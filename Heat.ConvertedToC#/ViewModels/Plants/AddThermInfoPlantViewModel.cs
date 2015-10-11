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

		[Display(name = "Classe impianto")]
		public int PlantClassID { get; set; }
		public IEnumerable<SelectListItem> PlantClassList { get; set; }

		[Display(name = "Tipologia impianto")]
		public int PlantTypeID { get; set; }
		public IEnumerable<SelectListItem> PlantTypeList { get; set; }


		[Display(name = "Codice dell'impianto per la provincia")]
		public string PlantDistinctCode { get; set; }


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

