using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Nosbor.FluentBuilder.Lib;

namespace AutomatedTestingInCSharp.UnitTest.Base
{
    public abstract class Builder<TEntidade> where TEntidade : class
    {
        protected FluentBuilder<TEntidade> FluentBuilder;

        protected Builder()
        {
            FluentBuilder = FluentBuilder<TEntidade>.New();
        }

        public Builder<TEntidade> With<TProperty>(Expression<Func<TEntidade, TProperty>> expressao, TProperty valor)
        {
            FluentBuilder.With(expressao, valor);
            return this;
        }

        public Builder<TEntidade> WithCollection<TCollectionProperty, TElement>(Expression<Func<TEntidade, TCollectionProperty>> expressao, params TElement[] elementos) where TCollectionProperty : IEnumerable<TElement>
        {
            FluentBuilder.WithCollection(expressao, elementos);
            return this;
        }

        public TEntidade Build()
        {
            return FluentBuilder.Build();
        }
    }
}
