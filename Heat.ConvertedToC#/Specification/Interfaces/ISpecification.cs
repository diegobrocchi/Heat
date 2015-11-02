using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Specification
{
    interface ISpecification<T> where T : EntityObject
    {
        Expression<Func<T, bool>> Expression;
        bool IsSatisfiedBy(T candidate);

        //ISpecification<T> And(ISpecification<T> specification);
        //ISpecification<T> Or(ISpecification<T> specification);
        //ISpecification<T> Not(ISpecification<T> specification);
    }
}
