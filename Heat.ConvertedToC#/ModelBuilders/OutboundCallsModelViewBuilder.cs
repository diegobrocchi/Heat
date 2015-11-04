using Heat.ViewModels.OutboundCalls;
using Heat.Manager;
using Heat.ViewModels.OutboundCalls;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Heat.Models;

namespace Heat
{

    /// <summary>
    /// Costruisce tutti i modelli per le View
    /// </summary>
    public class OutboundCallsModelViewBuilder
    {
        private IHeatDBContext _db;
        private IOutboundCallsManager _ocm;

        public OutboundCallsModelViewBuilder(IHeatDBContext dbContext)
            : this(dbContext, new OutboundCallsManager(dbContext))
        {
        }

        public OutboundCallsModelViewBuilder(IHeatDBContext dbContext, IOutboundCallsManager manager)
        {
            _db = dbContext;
            _ocm = manager;
        }


        /// <summary>
        /// Genera la lista delle prossime chiamate
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public ProposedOutboundCallsViewModel GetNextProposed(OutboundCallsCriteria criteria)
        {
            ProposedOutboundCallsViewModel result = new ProposedOutboundCallsViewModel();
            result.User = criteria.Login ;
            result.Calls = _ocm.GetNextOutboundCallSet(criteria);
            return result;

        }

        /// <summary>
        /// Costruisce il modello per la view con l'elenco delle chiamate già assegnate all'utente.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public AssignedOutboundCallViewModel GetIndexViewModel(string login)
        {
            AssignedOutboundCallViewModel result = new AssignedOutboundCallViewModel();
            result.Login = login;
            result.Calls = _ocm.GetAssignedOutboundSet(login);
            return result;
        }

        public CriteriaViewModel  GetCriteriaViewModel()
        {
            CriteriaViewModel result = new CriteriaViewModel();
            List<string> caps;
            List<string> cities;

            caps = _db.Addresses.Select(selector =>  selector.PostalCode ).Distinct().ToList();
            cities = _db.Addresses.Select(selector => selector.City).Distinct().ToList();
            result.CAPList = caps.ToSelectListItems(x => x.ToUpper() , x => x,"_ALLVALUES",  true, "_ALLVALUES", " - tutti i CAP - ");
            result.CityList = cities.ToSelectListItems(x => x.ToUpper(), x => x, "_ALLVALUES", true, "_ALLVALUES", " - tutte le città - ");
            result.DaysInFuture = 30;
            return result;

        }
    }
}
