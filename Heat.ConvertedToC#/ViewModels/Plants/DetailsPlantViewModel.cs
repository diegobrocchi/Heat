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
namespace Heat.ViewModels.Plants
{

	/// <summary>
	/// Modello per la vista Details per un impianto. I dati da presentare sono molti quindi vengono suddivisi in tab.
	/// Il modello è strutturato con un sub-modello per ogni tab.
	/// </summary>
	/// <remarks></remarks>
	public class DetailsPlantViewModel
	{

		public DetailsIdentifyPlantViewModel IdentifyViewModel { get; set; }
		public DetailsThermalPlantViewModel ThermalViewModel { get; set; }
		public DetailsContactPlantViewModel ContactViewModel { get; set; }
		public DetailsMediaPlantViewModel MediaViewModel { get; set; }
		public DetailsServicePlantViewModel ServiceViewModel { get; set; }
	}

}
