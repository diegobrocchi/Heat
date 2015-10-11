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
	/// Modello che viene mostrato nel datatable jQuery.
	/// E' un subset di Plant e contiene solo le proprietà da mostrare.
	/// </summary>
	public class IndexDataTablePlantViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		//Property PlantClass As String
		//Property PlantType As String
		public string PlantDistinctCode { get; set; }
	}
}

