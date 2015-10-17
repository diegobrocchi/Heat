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
namespace Heat
{
	/// <summary>
	/// Rappresenta una causale di movimento di magazzino.
	/// </summary>
	/// <remarks></remarks>
	public class CausalWarehouse
	{
		public int ID { get; set; }
		public string Code { get; set; }
		public int Sign { get; set; }

		public int TypeID { get; set; }
		public CausalWarehouseTypeEnum Type { get; set; }
		public bool Transaction { get; set; }

	}
}