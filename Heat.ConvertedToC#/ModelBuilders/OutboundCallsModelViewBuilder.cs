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
