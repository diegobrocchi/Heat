using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Converted.Tests.FakeContext
{
    class FakeHeaterDbSet : FakeDbSet<Models.Heater >
    {
        public override Models.Heater Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.ID == (int)keyValues.Single());
        }
    }
}
