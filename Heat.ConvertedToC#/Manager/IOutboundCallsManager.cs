using System;
using System.Collections.Generic;
using Heat.Models;

namespace Heat.Manager
{
    public interface IOutboundCallsManager
    {
        List<ProposedOutBoundCall> GetNextOutboundCallSet(string login);
        List<AssignedOutboundCall> GetAssignedOutboundSet(string login);
    }
}
