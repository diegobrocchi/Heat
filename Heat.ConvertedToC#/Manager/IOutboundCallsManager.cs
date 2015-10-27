using System;
using Heat.Models;

namespace Heat.Manager
{
    public interface IOutboundCallsManager
    {
        System.Collections.Generic.List<ProposedOutBoundCall> GetNextOutboundCallSet(string login);
    }
}
