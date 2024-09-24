﻿using AzureSearchToolkit.Logging;
using Microsoft.Azure.Search.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureSearchToolkit
{
    public interface IAzureSearchConnection
    {
        /// <summary>
        /// Returns all index names within the resource.
        /// </summary>
        Task<IList<string>> ListIndexesAsync();

        /// <summary>
        /// Create index if it does not exists applying scoring profiles
        /// </summary>
        /// <returns>If the index was created, true is returned, otherwise false</returns>
        Task<bool> EnsureSearchIndexAsync<T>(IndexScoringProfiles scoringProfiles = null, ILogger logger = null) where T : class;

        /// <summary>
        /// Change documents in index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="changedDocuments">Dictionary with documents to change. Included are AzureSearchIndexType operation for each document.</param>
        /// <returns>If documents were succesfully changed, true is returned, otherwise false</returns>
        Task<bool> ChangeDocumentsInIndexAsync<T>(SortedDictionary<T, IndexActionType> changedDocuments, ILogger logger = null) where T : class;

        /// <summary>
        /// Deletes index if exists.
        /// </summary>
        Task<bool> DeleteIndexAsync<T>(ILogger logger = null) where T : class;

        /// <summary>
        /// Returns index statitics: documents count and storage size.
        /// </summary>
        Task<IndexGetStatisticsResult> GetIndexStatisticsAsync<T>(ILogger logger = null) where T : class;

        /// <summary>
        /// Issues search requests to AzureSearch.
        /// </summary>
        /// <param name="searchParameters">Search parameters for the request.</param>
        /// <param name="searchText">The search text applied to the request.</param>
        /// <param name="logger">The logging mechanism for diagnostic information.</param>
        /// <returns>An AzureOperationResponse object containing the desired search results.</returns>
        Task<AzureOperationResponse<DocumentSearchResult<Document>>> SearchAsync(SearchParameters searchParameters, Type searchType, 
            string searchText = null, ILogger logger = null);

        Task<DocumentSearchResult<TResult>> SearchAsync<TResult>(SearchParameters searchParameters,
            string searchText = null, ILogger logger = null);
    }
}
