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

	/// <summary>
	/// Rappresenta un oggetto di tipo grafico o audio o video o whatever caricata come allegato ad un'altra entità.
	/// </summary>
	public class Medium
	{

		public int ID { get; set; }
		public string OriginalFileName { get; set; }
		public string UploadFileName { get; set; }
		public string RelativePath { get; set; }
		public string AbsolutePath { get; set; }
		public int Lenght { get; set; }
		public string Extension { get; set; }
		public string ContentType { get; set; }
		public string Description { get; set; }
		public string Tags { get; set; }

	}
}

