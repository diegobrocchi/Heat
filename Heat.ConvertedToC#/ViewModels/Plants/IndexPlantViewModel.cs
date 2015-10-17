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
	public class IndexPlantViewModel
	{
		public int ID { get; set; }

		[Display(name = "Nominativo")]
		public string Name { get; set; }

		[Display(name = "Classe impianto")]
		public string PlantClass { get; set; }

		[Display(name = "Tipologia impianto")]
		public string PlantType { get; set; }

		[Display(name = "Codice dell'impianto per la provincia")]
		public string PlantDistinctCode { get; set; }

		[Display(name = "Indirizzo")]
		public string Address { get; set; }



	}

}