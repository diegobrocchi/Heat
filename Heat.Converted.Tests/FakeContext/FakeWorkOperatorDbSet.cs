using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Converted.Tests.FakeContext
{
    class FakeWorkOperatorDbSet : FakeDbSet<Models.WorkOperator>
    {
        public override Models.WorkOperator Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.ID == (int)keyValues.Single());
        }
    }
}
