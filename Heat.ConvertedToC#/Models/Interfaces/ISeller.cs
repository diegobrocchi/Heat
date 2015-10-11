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
	/// Un ente che può emettere una fattura
	/// </summary>
	/// <remarks></remarks>
	public interface ISeller
	{
		/// <summary>
		/// Identificativo univoco 
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		int ID { get; set; }
		/// <summary>
		/// Nome o ragione sociale
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		string Name { get; set; }
		/// <summary>
		/// Indirizzo della sede legale
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		Address Address { get; set; }
		/// <summary>
		/// Numero di Partita IVA
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		string Vat_Number { get; set; }
		/// <summary>
		/// Codice fiscale
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		string FiscalCode { get; set; }
		/// <summary>
		/// Codice IBAN 
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		string IBAN { get; set; }
		/// <summary>
		/// Percorso del file del logo
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		string Logo { get; set; }
	}

}
