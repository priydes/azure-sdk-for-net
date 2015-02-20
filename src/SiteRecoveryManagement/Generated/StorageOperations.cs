// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hyak.Common;
using Hyak.Common.Internals;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.WindowsAzure.Management.SiteRecovery
{
    /// <summary>
    /// Definition of storage operations for the Site Recovery extension.
    /// </summary>
    internal partial class StorageOperations : IServiceOperations<SiteRecoveryManagementClient>, IStorageOperations
    {
        /// <summary>
        /// Initializes a new instance of the StorageOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal StorageOperations(SiteRecoveryManagementClient client)
        {
            this._client = client;
        }
        
        private SiteRecoveryManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Management.SiteRecovery.SiteRecoveryManagementClient.
        /// </summary>
        public SiteRecoveryManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Get the list of all storages under the vault.
        /// </summary>
        /// <param name='serverId'>
        /// Required. Server Id.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response model for the list storage operation.
        /// </returns>
        public async Task<StorageListResponse> ListAsync(string serverId, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken)
        {
            // Validate
            if (serverId == null)
            {
                throw new ArgumentNullException("serverId");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serverId", serverId);
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/cloudservices/";
            url = url + Uri.EscapeDataString(this.Client.CloudServiceName);
            url = url + "/resources/";
            url = url + "WAHyperVRecoveryManager";
            url = url + "/~/";
            url = url + "HyperVRecoveryManagerVault";
            url = url + "/";
            url = url + Uri.EscapeDataString(this.Client.ResourceName);
            url = url + "/Storages";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2015-02-10");
            queryParameters.Add("ServerId=" + Uri.EscapeDataString(serverId));
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept", "application/xml");
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                httpRequest.Headers.Add("x-ms-version", "2013-03-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    StorageListResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new StorageListResponse();
                        XDocument responseDoc = XDocument.Parse(responseContent);
                        
                        XElement arrayOfStorageSequenceElement = responseDoc.Element(XName.Get("ArrayOfStorage", "http://schemas.microsoft.com/windowsazure"));
                        if (arrayOfStorageSequenceElement != null)
                        {
                            foreach (XElement arrayOfStorageElement in arrayOfStorageSequenceElement.Elements(XName.Get("Storage", "http://schemas.microsoft.com/windowsazure")))
                            {
                                AsrStorage storageInstance = new AsrStorage();
                                result.Storages.Add(storageInstance);
                                
                                XElement typeElement = arrayOfStorageElement.Element(XName.Get("Type", "http://schemas.microsoft.com/windowsazure"));
                                if (typeElement != null)
                                {
                                    string typeInstance = typeElement.Value;
                                    storageInstance.Type = typeInstance;
                                }
                                
                                XElement fabricObjectIDElement = arrayOfStorageElement.Element(XName.Get("FabricObjectID", "http://schemas.microsoft.com/windowsazure"));
                                if (fabricObjectIDElement != null)
                                {
                                    string fabricObjectIDInstance = fabricObjectIDElement.Value;
                                    storageInstance.FabricObjectID = fabricObjectIDInstance;
                                }
                                
                                XElement fabricTypeElement = arrayOfStorageElement.Element(XName.Get("FabricType", "http://schemas.microsoft.com/windowsazure"));
                                if (fabricTypeElement != null)
                                {
                                    string fabricTypeInstance = fabricTypeElement.Value;
                                    storageInstance.FabricType = fabricTypeInstance;
                                }
                                
                                XElement serverIDElement = arrayOfStorageElement.Element(XName.Get("ServerID", "http://schemas.microsoft.com/windowsazure"));
                                if (serverIDElement != null)
                                {
                                    string serverIDInstance = serverIDElement.Value;
                                    storageInstance.ServerID = serverIDInstance;
                                }
                                
                                XElement nameElement = arrayOfStorageElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                                if (nameElement != null)
                                {
                                    string nameInstance = nameElement.Value;
                                    storageInstance.Name = nameInstance;
                                }
                                
                                XElement idElement = arrayOfStorageElement.Element(XName.Get("ID", "http://schemas.microsoft.com/windowsazure"));
                                if (idElement != null)
                                {
                                    string idInstance = idElement.Value;
                                    storageInstance.ID = idInstance;
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Get the list of all storages for the subscription
        /// </summary>
        /// <param name='subscriptionId'>
        /// Optional.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List Storage Accounts operation response.
        /// </returns>
        public async Task<StorageAccountListResponse> ListAzureStoragesAsync(string subscriptionId, CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("subscriptionId", subscriptionId);
                TracingAdapter.Enter(invocationId, this, "ListAzureStoragesAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/";
            if (subscriptionId != null)
            {
                url = url + Uri.EscapeDataString(subscriptionId);
            }
            url = url + "/services/storageservices";
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-03-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    StorageAccountListResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new StorageAccountListResponse();
                        XDocument responseDoc = XDocument.Parse(responseContent);
                        
                        XElement storageServicesSequenceElement = responseDoc.Element(XName.Get("StorageServices", "http://schemas.microsoft.com/windowsazure"));
                        if (storageServicesSequenceElement != null)
                        {
                            foreach (XElement storageServicesElement in storageServicesSequenceElement.Elements(XName.Get("StorageService", "http://schemas.microsoft.com/windowsazure")))
                            {
                                StorageAccountListResponse.StorageAccount storageServiceInstance = new StorageAccountListResponse.StorageAccount();
                                result.StorageAccounts.Add(storageServiceInstance);
                                
                                XElement urlElement = storageServicesElement.Element(XName.Get("Url", "http://schemas.microsoft.com/windowsazure"));
                                if (urlElement != null)
                                {
                                    Uri urlInstance = TypeConversion.TryParseUri(urlElement.Value);
                                    storageServiceInstance.Uri = urlInstance;
                                }
                                
                                XElement serviceNameElement = storageServicesElement.Element(XName.Get("ServiceName", "http://schemas.microsoft.com/windowsazure"));
                                if (serviceNameElement != null)
                                {
                                    string serviceNameInstance = serviceNameElement.Value;
                                    storageServiceInstance.Name = serviceNameInstance;
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}