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
	/// Schema di numerazione utilizzabile per un numeratore.
	/// Specifica il modo in cui viene creato un numero di serie.
	/// </summary>
	/// <remarks></remarks>
	public class SerialScheme
	{
		public int ID { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }


		/// <summary>
		/// Valore iniziale della serie; se lo schema prevede il riciclo è il numero da cui riparte.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public int InitialValue { get; set; }

		/// <summary>
		/// Valore dell'incremento tra un elemento della serie e il successivo.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public int Increment { get; set; }

		/// <summary>
		/// Se diverso da Nothing è il valore minimo assegnabile a un elemento della serie.
		/// Se è nullo allora il valore minimo assegnabile è Integer.minValue.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public Nullable<int> MinValue { get; set; }

		/// <summary>
		/// Se diverso da Nothing è il valore massimo assegnabile a un elemento della serie.
		/// Se è Nothing allora il valore massimo assegnabile è Integer.MaxValue.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public Nullable<int> MaxValue { get; set; }

		/// <summary>
		/// Stringa di formattazione da utilizzare per la rappresentazione testuale del numero della serie.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public string FormatMask { get; set; }

		/// <summary>
		/// Data ultima di validità dello schema; viene ricalcolata se RecycleWhenExpired = true.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public Nullable<DateTime> ExpiryDate { get; set; }

		/// <summary>
		/// Indica se lo schema deve essere re-inizializzato quando scade.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public bool RecycleWhenExpired { get; set; }

		/// <summary>
		/// Indica il periodo di tempo di validità dello schema (nessuno, giornaliero, settimanale, mensile, annuale).
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public Nullable<Periodicity> Period { get; set; }

		/// <summary>
		/// Indica se lo schema deve essere re-inizializzato quando viene raggiunto il massimo.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public bool RecycleWhenMaxIsReached { get; set; }

	}
}
