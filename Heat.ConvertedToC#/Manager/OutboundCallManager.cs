using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Heat.Models;
using System;
//using Heat.ViewModels.OutboundCalls;

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
        /// <returns>La generazione proposta</returns>
        public ProposedCallsGeneration GetNextOutboundCallSet(OutboundCallsCriteria criteria)
        {
            //List<ProposedOutBoundCall> result = new List<ProposedOutBoundCall>();
            ProposedCallsGeneration result = new ProposedCallsGeneration(criteria.Login);

            //List<ProposedOutboundCallsGridViewModel> viewResult = new List<ProposedOutboundCallsGridViewModel>();
            List<ProposedOutBoundCallDTO> tempResult;

            IQueryable<Plant> expiringServicePlants = null;

            //cancella tutte le chiamate proposte all'utente pre-esistenti 
            _db.ProposedOutboundCalls.RemoveRange(_db.ProposedOutboundCalls.Where(x => x.User == criteria.Login));
            //_db.SaveChanges();

            //cerca gli impianti con la manutenzione scaduta o in scadenza nei prossimi X giorni
            //esclude gli impianti che abbiano una data di manutenzione fissata nel futuro
            System.DateTime stopDate = DateTime.Now.AddDays(criteria.DaysInFuture);

            expiringServicePlants = _db.Plants.Include(x=> x.Service).Where(plant => plant.Service.LegalExpirationDate <= stopDate || plant.Service.PlannedServiceDate < DateTime.Now);

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

            if (criteria.PlantClass != null)
            {
                userFilteredPlants = userFilteredPlants.Where(plant => plant.PlantClass.Name == criteria.PlantClass);
            }

            if ( criteria.PlantType != null)
            {
                userFilteredPlants = userFilteredPlants.Where(plant => plant.PlantType.Name == criteria.PlantType);
            }

            //con LINQ to Entities non è possibile fare proiezioni su entità,
            //quindi è necessario fare 2 giri: 
            //il primo estrae i valori in un DTO, il secondo genera le entità
            tempResult = userFilteredPlants.Include(x=> x.BuildingAddress).Include(x => x.Contacts ).Select(x => new ProposedOutBoundCallDTO
            {
                PlantID = x.ID,
                User = criteria.Login,
                MainPhoneNumber = x.Contacts.FirstOrDefault().CellPhone,
                Address = x.BuildingAddress.Address,
                City = x.BuildingAddress.City,
                ContactName = x.Contacts.FirstOrDefault().Name,
                PlantRegionalID = x.PlantDistinctCode,
                Contacts = x.Contacts 
            }).ToList();


            result.Calls  = tempResult.Select(x => new ProposedOutBoundCall
            {
                 
                PlantID = x.PlantID,
                User = x.User
                //Contacts = x.Contacts 
            }).ToList();

            _db.ProposedOutboundCalls.AddRange(result.Calls );
            _db.ProposedCallsGenerations.Add(result );
            _db.SaveChanges();

            return result ;
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
        public OutboundCallsCriteria ToCriteria(ViewModels.OutboundCalls.CriteriaViewModel viewCriteria)
        {
            OutboundCallsCriteria result = new OutboundCallsCriteria();

            result.TotalNumber = viewCriteria.CallsNumber;

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

            if (viewCriteria.PlantClassSelected == "_ALLVALUES")
            {
                result.PlantClass = null;
            }
            else
            {
                result.PlantClass = viewCriteria.PlantClassSelected;
            }

            if (viewCriteria.PlantTypeSelected =="_ALLVALUES")
            {
                result.PlantType = null;
            }
            else
            {
                result.PlantType = viewCriteria.PlantTypeSelected;
            }

            return result;
        }

        public void ConfirmProposedCalls(int generationID)
        {
            //cerca le chiamate proposte
            var proposedCalls = _db.ProposedCallsGenerations.Include(x=> x.Calls.Select(c=> c.Plant )).Where(x => x.ID == generationID).Single().Calls;
            
            foreach (var call in proposedCalls )
            {
                AssignedOutboundCall target = new AssignedOutboundCall();
                target.AssignmentDate = DateTime.Now;
                target.ContactName = call.Plant.Name;
                target.User = call.User;

                _db.AssignedOutboundCalls.Add(target);
            }

            _db.SaveChanges();

        }
    }
}
