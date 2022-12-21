﻿using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AzureSearchToolkit.Async
{
    /// <summary>
    /// Defines methods to asynchronously execute queries that are described by an <see cref="T:System.Linq.IQueryable" /> object.
    /// </summary>
    public interface IAsyncQueryExecutor
    {
        /// <summary>
        /// Executes the query represented by a specified expression tree asynchronously.
        /// </summary>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <param name="cancellationToken">The optional token to monitor for cancellation requests.</param>
        /// <returns>The task that returns the value that results from executing the specified query.</returns>
        Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes the strongly-typed query represented by a specified expression tree asynchronously.
        /// </summary>
        /// <typeparam name="TResult">The type of the value that results from executing the query.</typeparam>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <param name="cancellationToken">The optional token to monitor for cancellation requests.</param>
        /// <returns>The task that returns the value that results from executing the specified query.</returns>
        Task<IEnumerable<TResult>> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default(CancellationToken)) where TResult: class;
    }
}
