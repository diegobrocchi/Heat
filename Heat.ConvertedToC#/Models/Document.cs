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
namespace Heat.Models
{

	public abstract class Document
	{
		public int ID { get; set; }

		public int TemporaryNumber { get; set; }
		public string TemporaryStringNumber { get; set; }
		public int Number { get; set; }
		public string StringNumber { get; set; }
		public Customer Customer { get; set; }
		public DateTime PrintDate { get; set; }
		public Numbering Numerator { get; set; }
		public HeatUser CreateUser { get; set; }
		public DateTime CreationDate { get; set; }
		public HeatUser LastModifyUser { get; set; }
		public DateTime LastModifyDate { get; set; }
		public DocumentState State { get; set; }
	}

	public enum DocumentState
	{
		Inserted = 0,
		Confirmed = 1,
		Deleted = 3

	}
}

