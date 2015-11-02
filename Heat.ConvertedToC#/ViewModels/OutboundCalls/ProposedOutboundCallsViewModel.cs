using System.Collections.Generic;
namespace Heat.ViewModels.OutboundCall
{

    public class ProposedOutboundCallsViewModel
	{
		public int ID { get; set; }

		public string User { get; set; }
		public string Name { get; set; }
		public int PlantID { get; set; }
		public string PlantDetails { get; set; }
		public string Telephone1 { get; set; }
		public string Telephone2 { get; set; }

        public string Login { get; set; }
        public List<Models.ProposedOutBoundCall> Calls { get; set; }

	}
}
