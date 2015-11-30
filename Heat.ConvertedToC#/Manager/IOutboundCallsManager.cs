using System;
using System.Collections.Generic;
using Heat.Models;
using Heat.ViewModels.OutboundCalls;

namespace Heat.Manager
{

    /// <summary>
    /// Si occupa delle logiche di business relative alle chiamate da effettuare agli impianti in scadenza.
    /// </summary>
    public interface IOutboundCallsManager
    {
        //List<ProposedOutboundCallsGridViewModel> GetNextOutboundCallSet(OutboundCallsCriteria criteria);
        ProposedCallsGeneration GetNextOutboundCallSet(OutboundCallsCriteria criteria);
        List<AssignedOutboundCall> GetAssignedOutboundSet(string login);
    }
}
