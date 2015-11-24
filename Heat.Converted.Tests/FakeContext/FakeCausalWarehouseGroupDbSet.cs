using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Converted.Tests.FakeContext
{
    class FakeCausalWarehouseGroupDbSet : FakeDbSet<Models.CausalWarehouseGroup>
    {
        public override Models.CausalWarehouseGroup Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.ID == (int)keyValues.Single());
        }
    }
}
