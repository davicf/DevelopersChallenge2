using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xayah.Finances.Contracts.Data.Specification;

namespace Xayah.Finances.Data.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criterion { get; }
        public List<Expression<Func<T, object>>> Inclusions { get; } = new List<Expression<Func<T, object>>>();
        public IList<string> SubInclusions { get; } = new List<string>();
        public List<Expression<Func<T, object>>> InclusionsFilter { get; } = new List<Expression<Func<T, object>>>();

        protected Specification(Expression<Func<T, bool>> criterion) => Criterion = criterion;

        protected void AddInclusion(Expression<Func<T, object>> inclusao) => Inclusions.Add(inclusao);

        protected void AddInclusionFilter(Expression<Func<T, object>> inclusao) => InclusionsFilter.Add(inclusao);

        protected void AddSubInclusion<TSubInclusion>(Expression<Func<T, object>> property, Expression<Func<TSubInclusion, object>> subInclusion)
        {
            var expression = property.ToString();
            var nameProperty = expression.Substring(expression.IndexOf('.') + 1);
            var expressionSubInclusion = subInclusion.ToString();
            var pathInclusion = expressionSubInclusion.Substring(expressionSubInclusion.IndexOf('.') + 1);

            SubInclusions.Add($"{nameProperty}.{pathInclusion}");
        }
    }
}