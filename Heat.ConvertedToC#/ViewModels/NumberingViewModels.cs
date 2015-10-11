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
using Heat.Models;
namespace Heat
{

	public class IndexNumberingViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(name = "Codice")]
		public string Code { get; set; }

		[Display(name = "Descrizione")]
		public string Description { get; set; }

		[Display(name = "Schema di numerazione provvisorio")]
		public string TempSerialSchema { get; set; }

		[Display(name = "Schema di numerazione definitivo")]
		public string FinalSerialSchema { get; set; }

	}
}
namespace Heat
{

	public class CreateNumberingViewModel
	{

		[Required()]
		[Display(name = "Codice")]
		public string Code { get; set; }

		[Required()]
		[Display(name = "Descrizione")]
		public string Description { get; set; }

		[Required()]
		[Display(name = "Schema di numerazione provvisorio")]
		public int TempSerialSchemaID { get; set; }

		public IEnumerable<SelectListItem> TempSerialSchemaList { get; set; }

		[Required()]
		[Display(name = "Schema di numerazione definitivo")]
		public int FinalSerialSchemaID { get; set; }

		public IEnumerable<SelectListItem> FinalSerialSchemaList { get; set; }

	}
}
namespace Heat
{

	public class EditNumberingViewModel
	{
		[Key()]
		[HiddenInput()]
		public int ID { get; set; }

		[Required()]
		[Display(name = "Codice")]
		public string Code { get; set; }

		[Required()]
		[Display(name = "Descrizione")]
		public string Description { get; set; }

		[Required()]
		[Display(name = "Schema di numerazione provvisorio")]
		public int TempSerialSchemaID { get; set; }
		public IEnumerable<SelectListItem> TempSerialSchemaList { get; set; }

		[Required()]
		[Display(name = "Schema di numerazione definitivo")]
		public int FinalSerialSchemaID { get; set; }
		public IEnumerable<SelectListItem> FinalSerialSchemaList { get; set; }

	}
}



//Imports System.ComponentModel.DataAnnotations

//Public Class CreateNumberingViewModel
//    <Required> _
//    <Display(name:="Codice")> _
//    Property Code As String

//    <Required> _
//    <Display(name:="Descrizione")> _
//    Property Description As String

//    <Required> _
//    <Display(name:="Schema di numerazione progressivo")> _
//    Property TempSerialSchema As IEnumerable(Of SelectListItem)

//    <Required> _
//    <Display(name:="Schema di numerazione definitivo")> _
//    Property FinalSerialSchema As IEnumerable(Of SelectListItem)

//End Class
