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
	/// Rappresenta un intervento di lavoro.
	/// </summary>
	/// <remarks></remarks>
	public class WorkAction
	{

		public int ID { get; set; }

		public DateTime ActionDate { get; set; }
		public int OperationID { get; set; }
		public Operation Operation { get; set; }
		public int AssignedOperatorID { get; set; }
		public WorkOperator AssignedOperator { get; set; }
		public int TypeID { get; set; }
		public ActionType Type { get; set; }
		public int PlantID { get; set; }
		public Plant Plant { get; set; }

	}

}

