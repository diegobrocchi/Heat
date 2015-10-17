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

namespace Heat.Manager
{
	/// <summary>
	/// Il gestore delle chiamate ai contatti.
	/// </summary>
	public class OutboundCallsManager
	{


		private IHeatDBContext _db;
		public OutboundCallsManager(IHeatDBContext dbContext)
		{
			_db = dbContext;
		}

		/// <summary>
		/// Genera una lista di chiamate da effettuare.
		/// Le chiamate sono relative agli impianti con la manutenzione scaduta o in scadenza.
		/// Genera una lista diversa per ogni utente.
		/// </summary>
		/// <param Name="login"></param>
		/// <returns></returns>
		public List<ProposedOutBoundCall> GetNextOutboundCallSet(string login)
		{
			List<ProposedOutBoundCall> result = new List<ProposedOutBoundCall>();
			List<Plant> expiringServicePlants = null;

			//cerca gli impianti con la manutenzione scaduta o in scadenza nei prossimi 30 giorni
			//esclude gli impianti che abbiano una data di manutenzione fissata nel futuro
			System.DateTime stopDate = DateAndTime.Now.AddDays(30);
			expiringServicePlants = _db.Plants.Where(x => x.Service.LegalExpirationDate <= stopDate & x.Service.PlannedServiceDate < DateAndTime.Now).ToList();

			//esclude quelli per i quali sono già assegnate chiamate
			List<Plant> pendingCallPlants = null;
			pendingCallPlants = expiringServicePlants.Except(_db.ProposedOutboundCalls.Select(x => x.Plant).ToList()).ToList();

			result = pendingCallPlants.Select(x => new ProposedOutBoundCall {
				Plant = x,
				Contacts = x.Contacts,
				PlantID = x.ID,
				User = login
			}).ToList();

			return result;

		}
	}
}
