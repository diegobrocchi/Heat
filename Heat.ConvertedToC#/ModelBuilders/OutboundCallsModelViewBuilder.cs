using Heat.ViewModels.OutboundCalls;
using Heat.Manager;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Heat.Models;
using AutoMapper;

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
            ProposedCallsGeneration generation = _ocm.GetNextOutboundCallSet(criteria);

            result.User = criteria.Login ;
            result.ProposedGenerationID = generation.ID;
            result.GenerationDate = generation.GenerationDate;
            result.Calls = Mapper.Map<List<ProposedOutboundCallsGridViewModel>>(generation.Calls);
            //int res = _ocm.GetNextOutboundCallSet(criteria);
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
            List<string> plantClasses;
            List<string> plantTypes;

            caps = _db.Addresses.Select(selector =>  selector.PostalCode ).Distinct().ToList();
            cities = _db.Addresses.Select(selector => selector.City).Distinct().ToList();
            plantClasses = _db.PlantClasses.Select(selector => selector.Name).ToList();
            plantTypes = _db.PlantTypes.Select(selector => selector.Name).ToList();
            result.CAPList = caps.ToSelectListItems(x => x.ToUpper() , x => x,"_ALLVALUES",  true, "_ALLVALUES", " - tutti i CAP - ");
            result.CityList = cities.ToSelectListItems(x => x.ToUpper(), x => x, "_ALLVALUES", true, "_ALLVALUES", " - tutte le città - ");
            result.PlantClassList = plantClasses.ToSelectListItems(x => x.ToUpper(), x => x, "_ALLVALUES", true, "_ALLVALUES", " - tutti le classi impianto - ");
            result.PlantTypeList = plantTypes.ToSelectListItems(x => x.ToUpper(), x => x, "_ALLVALUES", true, "_ALLVALUES", " - tutti i tipi impianto - ");
            result.DaysInFuture = 30;
            result.CallsNumber = 5;

            return result;

        }
    }
}
