using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Heat.Models;
using System;
using Heat.ViewModels.OutboundCalls;

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
        public List<ProposedOutboundCallsGridViewModel> GetNextOutboundCallSet(OutboundCallsCriteria criteria)
        {
            List<ProposedOutBoundCall> result = new List<ProposedOutBoundCall>();
            List<ProposedOutboundCallsGridViewModel> viewResult = new List<ProposedOutboundCallsGridViewModel>();
            List<ProposedOutBoundCallDTO> tempResult;


            IQueryable<Plant> expiringServicePlants = null;

            //cancella tutte le chiamate proposte all'utente pre-esistenti 
            _db.ProposedOutboundCalls.RemoveRange(_db.ProposedOutboundCalls.Where(x => x.User == criteria.Login));
            _db.SaveChanges();

            //cerca gli impianti con la manutenzione scaduta o in scadenza nei prossimi X giorni
            //esclude gli impianti che abbiano una data di manutenzione fissata nel futuro
            System.DateTime stopDate = DateTime.Now.AddDays(criteria.DaysInFuture);
            expiringServicePlants = _db.Plants.Where(plant => plant.Service.LegalExpirationDate <= stopDate || plant.Service.PlannedServiceDate < DateTime.Now);

            //esclude quelli per i quali sono già assegnate chiamate
            IQueryable<Plant> notPendingCallPlants;
            notPendingCallPlants = expiringServicePlants.Except(_db.ProposedOutboundCalls.Select(x => x.Plant));

            //applica i filtri eventalmente impostati dall'utente
            IQueryable<Plant> userFilteredPlants = notPendingCallPlants;
            if (criteria.CAP != null)
            {
                userFilteredPlants = userFilteredPlants.Where(plant => plant.BuildingAddress.PostalCode == criteria.CAP);
            }

            if (criteria.City != null)
            {
                userFilteredPlants = userFilteredPlants.Where(plant => plant.BuildingAddress.City == criteria.City);
            }

            //con LINQ to Entities non è possibile fare proiezioni su entità,
            //quindi è necessario fare 2 giri: 
            //il primo estrae i valori in un DTO, il secondo genera le entità
            tempResult = userFilteredPlants.Include(x=> x.BuildingAddress).Select(x => new ProposedOutBoundCallDTO
            {
                PlantID = x.ID,
                User = criteria.Login,
                MainPhoneNumber = x.Contacts.FirstOrDefault().CellPhone,
                Address = x.BuildingAddress.Address,
                City = x.BuildingAddress.City,
                ContactName = x.Contacts.FirstOrDefault().Name,
                PlantRegionalID = x.PlantDistinctCode 
            }).ToList();


            result = tempResult.Select(x => new ProposedOutBoundCall
            {
                PlantID = x.PlantID,
                User = x.User
            }).ToList();

            ProposedCallsGeneration generation = new ProposedCallsGeneration();
            generation.Calls = result;
            
            viewResult = tempResult.Select(x => new ProposedOutboundCallsGridViewModel
                {
                    Address = x.Address,
                    City = x.City,
                    ContactName = x.ContactName,
                    MainPhoneNumber = x.MainPhoneNumber,
                    PlantRegionalID = x.PlantRegionalID
                }).ToList();

            _db.ProposedOutboundCalls.AddRange(result);
            _db.SaveChanges();

            return viewResult;
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

        /// <summary>
        /// Converte i criteri assegnati dall'utente in un oggetto OutboundCallsCriteria
        /// </summary>
        /// <param name="viewCriteria"></param>
        /// <returns></returns>
        public OutboundCallsCriteria ToCriteria(CriteriaViewModel viewCriteria)
        {
            OutboundCallsCriteria result = new OutboundCallsCriteria();
            if (viewCriteria.DaysInFuture == 0)
            {
                result.DaysInFuture = 30; //default value
            }
            else
            {
                result.DaysInFuture = viewCriteria.DaysInFuture;
            }

            if (viewCriteria.SelectedCAP == "_ALLVALUES")
            {
                result.CAP = null;
            }
            else
            {
                result.CAP = viewCriteria.SelectedCAP;
            }
            if (viewCriteria.SelectedCity == "_ALLVALUES")
            {
                result.City = null;
            }
            else
            {
                result.City = viewCriteria.SelectedCity;
            }
            return result;
        }
    }
}
