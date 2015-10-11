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

	public class DetailsServicePlantViewModel
	{

		public int ID { get; set; }

		public int PlantID { get; set; }


		[Display(Name = "Data ultima manutenzione eseguita")]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public Nullable<DateTime> PreviousServiceDate { get; set; }

		[Display(Name = "Periodicità")]
		public Periodicity Periodicity { get; set; }

		[Display(Name = "Scadenza")]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime LegalExpirationDate { get; set; }

		[Display(Name = "Data programmata della manutenzione")]
		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime PlannedServiceDate { get; set; }
	}
}
