using System;
using System.Collections.Generic;
namespace Heat.ViewModels.OutboundCalls
{

    public class ProposedOutboundCallsViewModel
	{
        //public int ID { get; set; }

        public string User { get; set; }
        //public string Name { get; set; }
        //public int PlantID { get; set; }
        //public string PlantDetails { get; set; }
        //public string Telephone1 { get; set; }
        //public string Telephone2 { get; set; }


        public int ProposedGenerationID { get; set; }
        public DateTime GenerationDate { get; set; }
        public string Login { get; set; }
        public List<ProposedOutboundCallsGridViewModel> Calls { get; set; }

	}
}
