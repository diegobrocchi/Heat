using Heat.ViewModels.OutboundCall;
using Heat.Manager;
using Heat.ViewModels.OutboundCalls;
using System.Collections.Generic;
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

		public ProposedOutboundCallsViewModel GetNextProposed(string login)
		{
			ProposedOutboundCallsViewModel result = new ProposedOutboundCallsViewModel();

			result.User = login;

			return result;

		}

        /// <summary>
        /// Costruisce il modello per la view con l'elenco delle chiamate assegnate all'utente.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<AssignedOutboundCallViewModel> GetIndexViewModel(string login)
        {
            List<AssignedOutboundCallViewModel> result = new List<AssignedOutboundCallViewModel>();

            return result;
        }
    }
}
