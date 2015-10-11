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
namespace Heat
{

	public class CreateSerialSchemeViewModel
	{

		[Key()]
		public int ID { get; set; }

		[Required()]
		[Display(name = "Nome simbolico dello schema, serve come riferimento")]
		public string Name { get; set; }

		[Required()]
		[Display(name = "Descrizione breve dello schema")]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Required()]
		[Display(Name = "Valore iniziale della serie")]
		public int InitialValue { get; set; }

		[Required()]
		[Display(name = "Incremento")]
		public int Increment { get; set; }
		[Display(name = "Valore minimo assegnabile (può essere lasciato vuoto se non esiste il minimo)")]
		public Nullable<int> MinValue { get; set; }

		[Display(name = "Valore massimo assegnabile (può essere lasciato vuoto se non esiste il massimo)")]
		public Nullable<int> MaxValue { get; set; }

		[Display(name = "Schema di generazione del testo corrispondente al numero di serie")]
		public string FormatMask { get; set; }

		[Display(name = "Data di scadenza dello schema")]
		[DataType(DataType.Date), DisplayFormat(dataformatstring = "{0:yyyy-MM-dd}", applyFormatInEditMode = true)]
		public Nullable<DateTime> ExpiryDate { get; set; }

		[Display(name = "Riparte dal valore iniziale quando si supera la data di scadenza")]
		public bool RecycleWhenExpired { get; set; }

		[Display(name = "Periodicità")]
		public Nullable<Periodicity> Period { get; set; }

		[Display(name = "Riparte dal valore iniziale quando raggiunge il valore massimo")]
		public bool RecycleWhenMaxIsReached { get; set; }

	}
}
namespace Heat
{

	public class IndexSerialSchemeViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(name = "Nome")]
		public string Name { get; set; }

		[Display(name = "Descrizione")]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Display(name = "Incremento")]
		public int Increment { get; set; }

		[Display(name = "Periodicità")]
		public Periodicity Period { get; set; }

	}
}
