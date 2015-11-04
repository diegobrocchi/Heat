using System;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq.Expressions;

namespace Heat.Specification
{
    public  interface ISpecification<T> where T : EntityObject
    {
        //Expression<Func<T, bool>> Expression();
        bool IsSatisfiedBy(T candidate);

        //ISpecification<T> And(ISpecification<T> specification);
        //ISpecification<T> Or(ISpecification<T> specification);
        //ISpecification<T> Not(ISpecification<T> specification);
    }
}
