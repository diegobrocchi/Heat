using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Heat
{

    public class IndexNumberingViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Codice")]
		public string Code { get; set; }

		[Display(Name = "Descrizione")]
		public string Description { get; set; }

		[Display(Name = "Schema di numerazione provvisorio")]
		public string TempSerialSchema { get; set; }

		[Display(Name = "Schema di numerazione definitivo")]
		public string FinalSerialSchema { get; set; }

	}
}
namespace Heat
{

    public class CreateNumberingViewModel
	{

		[Required()]
		[Display(Name = "Codice")]
		public string Code { get; set; }

		[Required()]
		[Display(Name = "Descrizione")]
		public string Description { get; set; }

		[Required()]
		[Display(Name = "Schema di numerazione provvisorio")]
		public int TempSerialSchemaID { get; set; }

		public IEnumerable<SelectListItem> TempSerialSchemaList { get; set; }

		[Required()]
		[Display(Name = "Schema di numerazione definitivo")]
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
		[Display(Name = "Codice")]
		public string Code { get; set; }

		[Required()]
		[Display(Name = "Descrizione")]
		public string Description { get; set; }

		[Required()]
		[Display(Name = "Schema di numerazione provvisorio")]
		public int TempSerialSchemaID { get; set; }
		public IEnumerable<SelectListItem> TempSerialSchemaList { get; set; }

		[Required()]
		[Display(Name = "Schema di numerazione definitivo")]
		public int FinalSerialSchemaID { get; set; }
		public IEnumerable<SelectListItem> FinalSerialSchemaList { get; set; }

	}
}



//Imports System.ComponentModel.DataAnnotations

//Public Class CreateNumberingViewModel
//    <Required> _
//    <Display(Name:="Codice")> _
//    Property Code As String

//    <Required> _
//    <Display(Name:="Descrizione")> _
//    Property Description As String

//    <Required> _
//    <Display(Name:="Schema di numerazione progressivo")> _
//    Property TempSerialSchema As IEnumerable(Of SelectListItem)

//    <Required> _
//    <Display(Name:="Schema di numerazione definitivo")> _
//    Property FinalSerialSchema As IEnumerable(Of SelectListItem)

//End Class
