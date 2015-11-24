using System;
using System.Collections.Generic;
using Heat.Models;
using Heat.ViewModels.OutboundCalls;

namespace Heat.Manager
{
    public interface IOutboundCallsManager
    {
        //List<ProposedOutboundCallsGridViewModel> GetNextOutboundCallSet(OutboundCallsCriteria criteria);
        ProposedCallsGeneration GetNextOutboundCallSet(OutboundCallsCriteria criteria);
        List<AssignedOutboundCall> GetAssignedOutboundSet(string login);
    }
}
