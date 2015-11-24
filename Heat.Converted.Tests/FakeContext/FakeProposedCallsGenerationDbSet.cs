using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Converted.Tests.FakeContext
{
    class FakeProposedCallsGenerationDbSet : FakeDbSet<Models.ProposedCallsGeneration >
    {
        public override Models.ProposedCallsGeneration Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.ID == (int)keyValues.Single());
        }
    }
}
