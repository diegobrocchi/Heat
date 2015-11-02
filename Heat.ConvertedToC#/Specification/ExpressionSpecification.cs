using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heat.Specification
{
    public class ExpressionSpecification<T> : ISpecification<T>
    {
        private readonly Func<T, bool> _expression;

        internal ExpressionSpecification(Func<T, bool> Expression)
        {
            if (Expression == null)
            {
                throw new ArgumentNullException("Expression!");
            }
            _expression = Expression;
        }

        public bool IsSatisfiedBy(T candidate)
        {
            return this._expression(candidate);
        }
    }

}