using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heat.Models
{
    /// <summary>
    /// Rappresenta una generazione di OutboundCalls
    /// </summary>
    public class ProposedCallsGeneration
    {
        public int ID { get; set; }
        public DateTime GenerationDate { get; set; }
        public string User { get; set; }
        public List<ProposedOutBoundCall> Calls { get; set; }

    }
}