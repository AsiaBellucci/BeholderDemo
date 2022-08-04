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
        private HttpClient Client { get; set; }
        public string TokenString { get; set; }
        public string Domain { get; set; }

        public RemoteService()
            => Client = new();

        public async Task GetHealthDomainAsync(string domainName)
        {
            HttpRequestMessage request = new();
            request.Headers.Add("Authorization", $"Bearer {TokenString}");
            request.RequestUri = new Uri($"{Constants.ServiceUri}/api/HealthDomain/Get?key={domainName}");
            request.Method = HttpMethod.Get;
            try
            {
                var response = await Client.SendAsync(request);
                HealthLog log = new();
                if(response.Content != null)
                    log = JsonConvert.DeserializeObject<HealthLog>(await response.Content.ReadAsStringAsync());
                Domain = log.Domain;
                //HealthLog log = new HealthLog();
                //return JsonConvert.DeserializeObject<HealthLog>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                //return null;
            }

        }
    }
}