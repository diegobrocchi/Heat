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

namespace Heat.ViewModels.WorkActions
{
	public class CreateWorkActionViewModel
	{

		[Display(name = "Impianto")]
		public int PlantID { get; set; }
		[Display(name = "Riferita all'impianto")]
		public string PlantDescription { get; set; }
		public IEnumerable<SelectListItem> PlantList { get; set; }
		public bool PlantIDSelected { get; set; }

		[Display(name = "Data di esecuzione")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ActionDate { get; set; }

		[Display(name = "Tipo di operazione")]
		public int OperationID { get; set; }
		public IEnumerable<SelectListItem> OperationList { get; set; }

		[Display(name = "Operatore assegnato")]
		public int AssignedOperatorID { get; set; }
		public IEnumerable<SelectListItem> AssignedOperatorList { get; set; }

		[Display(name = "Tipo di operazione")]
		public int TypeID { get; set; }
		public IEnumerable<SelectListItem> TypeList { get; set; }

	}
}

