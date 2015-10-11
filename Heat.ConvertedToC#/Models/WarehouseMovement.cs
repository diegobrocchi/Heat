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

	public class WarehouseMovement
	{

		public int ID { get; set; }

		//EF by-configuration foreign key
		public int ProductID { get; set; }
		public Product Product { get; set; }

		public double Quantity { get; set; }
		[DataType(DataType.Date), DisplayFormat(dataformatstring = "{0:yyyy-MM-dd}", applyFormatInEditMode = true)]
		public System.DateTime ExecDate { get; set; }
		public string Note { get; set; }

		public int SourceID { get; set; }
		public Warehouse Source { get; set; }

		public int DestinationID { get; set; }
		public Warehouse Destination { get; set; }

		public int CausalWarehouseID { get; set; }
		public CausalWarehouse CausalWarehouse { get; set; }

	}
}
