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
            List<ProposedOutBoundCallDTO> tempResult;
            
            IQueryable<Plant> expiringServicePlants = null;

            //cancella tutte le chiamate proposte all'utente pre-esistenti 
            _db.ProposedOutboundCalls.RemoveRange(_db.ProposedOutboundCalls.Where(x => x.User == login));
            
            //cerca gli impianti con la manutenzione scaduta o in scadenza nei prossimi 30 giorni
            //esclude gli impianti che abbiano una data di manutenzione fissata nel futuro
            System.DateTime stopDate = DateAndTime.Now.AddDays(30);
            expiringServicePlants = _db.Plants.Where(x => x.Service.LegalExpirationDate <= stopDate & x.Service.PlannedServiceDate < DateAndTime.Now);

            //esclude quelli per i quali sono già assegnate chiamate
            IQueryable<Plant> pendingCallPlants = null;
            pendingCallPlants = expiringServicePlants.Except(_db.ProposedOutboundCalls.Select(x => x.Plant));

            tempResult = pendingCallPlants.Select(x => new ProposedOutBoundCallDTO
            {
                PlantID = x.ID,
                User = login,
                TelephoneNumber = "33342333"
            }).ToList();

            result = tempResult.Select(x => new ProposedOutBoundCall
            {
                PlantID = x.PlantID,
                User = x.User
            }).ToList();

            _db.ProposedOutboundCalls.AddRange(result);
            _db.SaveChanges();

            return result;
        }

        
        /// <summary>
        /// Ritorna la lista delle chiamate assegnate all'utente
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public List<AssignedOutboundCall> GetAssignedOutboundSet(string login)
        {
            List<AssignedOutboundCall> result;
            result = _db.AssignedOutboundCalls.Where(x => x.User == login).ToList();
            return result;

        }
    }
}
