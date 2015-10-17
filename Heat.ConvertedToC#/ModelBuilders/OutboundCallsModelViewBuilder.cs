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
using Heat.ViewModels.OutboundCall;
using Heat.Manager;
namespace Heat
{

	/// <summary>
	/// Costruisce tutti i modelli per le View
	/// </summary>
	public class OutboundCallsModelViewBuilder
	{
		private IHeatDBContext _db;

		private OutboundCallsManager _ocm;
		public OutboundCallsModelViewBuilder(IHeatDBContext dbContext)
		{
			_db = dbContext;
			_ocm = new OutboundCallsManager(_db);
		}

		public ProposedOutboundCallsViewModel GetNextProposed(string login)
		{
			ProposedOutboundCallsViewModel result = new ProposedOutboundCallsViewModel();

			result.User = login;

			return result;

		}
	}
}
