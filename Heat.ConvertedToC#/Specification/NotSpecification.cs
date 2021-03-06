﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;

namespace Heat.Specification
{
    internal class NotSpecification<T> : ISpecification<T> where T : EntityObject
    {
        private readonly ISpecification<T> _wrapped;

        protected ISpecification<T> Wrapped
        {
            get
            {
                return _wrapped;
            }
        }

        internal NotSpecification(ISpecification<T> Spec)
        {
            if (Spec == null)
            {
                throw new ArgumentNullException("Specification!");
            }
            _wrapped = Spec;
        }

        public bool IsSatisfiedBy(T candidate)
        {
            return !Wrapped.IsSatisfiedBy(candidate);
        }
    }
}