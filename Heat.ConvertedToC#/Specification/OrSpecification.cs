using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heat.Specification
{
    internal class OrSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _specification1;
        private readonly ISpecification<T> _specification2;

        protected ISpecification<T> Specification1
        {
            get
            {
                return _specification1;
            }
        }

        protected ISpecification<T> Specification2
        {
            get
            {
                return _specification2;
            }
        }

        internal OrSpecification(ISpecification<T> Spec1, ISpecification<T> Spec2)
        {
            if (Spec1== null)
            {
                throw new ArgumentNullException("Specification1!");
            }
            if(Spec2==null)
            {
                throw new ArgumentNullException("Specification2!");
            }

            _specification1= Spec1 ;
            _specification2 = Spec2 ;
        }

        public bool IsSatisfiedBy(T candidate)
        {
            return Specification1.IsSatisfiedBy(candidate) || Specification2.IsSatisfiedBy(candidate);
        }
    }
}