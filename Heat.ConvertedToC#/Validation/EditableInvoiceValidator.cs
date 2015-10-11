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
using Heat.Models;
namespace Heat
{

	/// <summary>
	/// Regola di validazione per una fattura editabile.
	/// Solo le fatture con State=DocumentState.Inserted sono modificabili.
	/// </summary>
	/// <remarks></remarks>
	public class EditableInvoiceValidator : IValidator
	{

		IHeatDBContext _db;

		int _invoiceID;
		public EditableInvoiceValidator(IHeatDBContext repository, int invoiceID)
		{
			_db = repository;
			_invoiceID = invoiceID;
		}

		public string ErrorMessage {
			get { return "Il documento non è modificabile"; }
		}

		public bool IsValid {
			get { return _db.Invoices.Find(_invoiceID).State == DocumentState.Inserted; }
		}
	}
}
