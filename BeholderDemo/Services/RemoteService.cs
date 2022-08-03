// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using BeholderDemo.Models;
using Microsoft.Datasync.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BeholderDemo.Services
{
    /// <summary>
    /// An implementation of the <see cref="ITodoService"/> interface that uses
    /// a remote table on a Datasync Service.
    /// </summary>
    public class RemoteService
    {

        /// <summary>
        /// When using authentication, the token requestor to use.
        /// </summary>
        public Func<Task<AuthenticationToken>> TokenRequestor;
        private HttpClient Client { get; set; }


        /// <summary>
        /// Creates a new <see cref="RemoteTodoService"/> with authentication.
        /// </summary>
        public RemoteService(Func<Task<AuthenticationToken>> tokenRequestor)
        {
            TokenRequestor = tokenRequestor;
            Client = new();
        }

        #region toAdjust
        /// <summary>
        /// Initialize the connection to the remote table.
        /// </summary>
        /// <returns></returns>
        //private async Task InitializeAsync()
        //{
        //    // Short circuit, in case we are already initialized.
        //    if (_initialized)
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        // Wait to get the async initialization lock
        //        await _asyncLock.WaitAsync();
        //        if (_initialized)
        //        {
        //            // This will also execute the async lock.
        //            return;
        //        }

        //        var options = new DatasyncClientOptions
        //        {
        //            HttpPipeline = new HttpMessageHandler[] { new LoggingHandler() }
        //        };

        //        // Initialize the client.
        //        _client = TokenRequestor == null
        //            ? new DatasyncClient(Constants.ServiceUri, options)
        //            : new DatasyncClient(Constants.ServiceUri, new GenericAuthenticationProvider(TokenRequestor), options);
        //        _table = _client.GetRemoteTable<TodoItem>();

        //        // Set _initialied to true to prevent duplication of locking.
        //        _initialized = true;
        //    }
        //    catch (Exception)
        //    {
        //        // Re-throw the exception.
        //        throw;
        //    }
        //    finally
        //    {
        //        _asyncLock.Release();
        //    }
        //}

        ///// <summary>
        ///// Get all the items in the list.
        ///// </summary>
        ///// <returns>The list of items (asynchronously)</returns>
        //public async Task<IEnumerable<TodoItem>> GetItemsAsync()
        //{
        //    await InitializeAsync();
        //    return await _table.GetAsyncItems().ToListAsync();
        //}

        ///// <summary>
        ///// Refreshes the TodoItems list manually.
        ///// </summary>
        ///// <returns>A task that completes when the refresh is done.</returns>
        //public async Task RefreshItemsAsync()
        //{
        //    await InitializeAsync();

        //    // Remote table doesn't need to refresh the local data.
        //    return;
        //}
        #endregion

        public async Task<HealthLog> GetHealthDomainAsync(string domainName)
        {
            HttpRequestMessage request = new();
            request.Headers.Add("Authentication", TokenRequestor.Invoke().Result.Token);
            request.RequestUri = new Uri($"{Constants.ServiceUri}/api/HealthDomain/Get?key={domainName}");
            request.Method = HttpMethod.Get;
            try
            {
                var response = await Client.SendAsync(request);
                HealthLog log = new HealthLog();
                return JsonConvert.DeserializeObject<HealthLog>(await response.Content.ReadAsStringAsync());
            }
            catch(Exception e)
            {
                return null;
            }

        }
    }
}