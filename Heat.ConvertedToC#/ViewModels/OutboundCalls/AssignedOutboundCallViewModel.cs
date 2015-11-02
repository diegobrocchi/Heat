using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heat.ViewModels.OutboundCalls
{
    public class AssignedOutboundCallViewModel
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string User { get; set; }
        public string ContactName { get; set; }
        public List<Models.AssignedOutboundCall> Calls { get; set; }
 
    }
}