using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using Heat.Models;

namespace Heat.Manager
{
    /// <summary>
    /// Il gestore delle chiamate ai contatti.
    /// </summary>
    public class OutboundCallsManager : IOutboundCallsManager
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

        public List<AssignedOutboundCall> GetAssignedOutboundSet(string login)
        {
            List<AssignedOutboundCall> result;
            result = _db.AssignedOutboundCalls.Where(x => x.User == login).ToList();
            return result;

        }
	}
}
