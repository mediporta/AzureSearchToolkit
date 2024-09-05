﻿using AzureSearchToolkit.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AzureSearchToolkit
{
    public class AzureSearchQuery<T> : IAzureSearchQuery<T>
    {
        readonly AzureSearchQueryProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureSearchQuery{T}"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="AzureSearchQueryProvider"/> used to execute the queries.</param>
        public AzureSearchQuery(AzureSearchQueryProvider provider)
        {
            Argument.EnsureNotNull(nameof(provider), provider);

            this.provider = provider;
            Expression = Expression.Constant(this);
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="provider">The <see cref="AzureSearchQueryProvider"/> used to execute the queries.</param>
        /// <param name="expression">The <see cref="Expression"/> that represents the LINQ query so far.</param>
        public AzureSearchQuery(AzureSearchQueryProvider provider, Expression expression)
        {
            Argument.EnsureNotNull(nameof(provider), provider);
            Argument.EnsureNotNull(nameof(expression), expression);

            if (!typeof(IQueryable<T>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException(nameof(expression));
            }
                
            this.provider = provider;
            Expression = expression;
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)provider.Execute(Expression)).GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)provider.Execute(Expression)).GetEnumerator();
        }

        /// <inheritdoc/>
        public Type ElementType => typeof(T);

        /// <inheritdoc/>
        public Expression Expression { get; }

        /// <inheritdoc/>
        public IQueryProvider Provider => provider;
    }
}
