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
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.Store;
using Microsoft.WindowsAzure.Management.Store.Models;

namespace Microsoft.WindowsAzure.Management.Store
{
    /// <summary>
    /// Provides REST operations for working with Store add-ins from the
    /// Windows Azure store service.
    /// </summary>
    internal partial class AddOnOperations : IServiceOperations<StoreManagementClient>, Microsoft.WindowsAzure.Management.Store.IAddOnOperations
    {
        /// <summary>
        /// Initializes a new instance of the AddOnOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal AddOnOperations(StoreManagementClient client)
        {
            this._client = client;
        }
        
        private StoreManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Management.Store.StoreManagementClient.
        /// </summary>
        public StoreManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// The Create Store Item operation creates Windows Azure Store entries
        /// in a Windows Azure subscription.
        /// </summary>
        /// <param name='cloudServiceName'>
        /// Required. The name of the cloud service to which this store item
        /// will be assigned.
        /// </param>
        /// <param name='resourceName'>
        /// Required. The name of this resource.
        /// </param>
        /// <param name='addOnName'>
        /// Required. The add on name.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters used to specify how the Create procedure will
        /// function.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationStatusResponse> BeginCreatingAsync(string cloudServiceName, string resourceName, string addOnName, AddOnCreateParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (cloudServiceName == null)
            {
                throw new ArgumentNullException("cloudServiceName");
            }
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }
            if (addOnName == null)
            {
                throw new ArgumentNullException("addOnName");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (parameters.Plan == null)
            {
                throw new ArgumentNullException("parameters.Plan");
            }
            if (parameters.Type == null)
            {
                throw new ArgumentNullException("parameters.Type");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cloudServiceName", cloudServiceName);
                tracingParameters.Add("resourceName", resourceName);
                tracingParameters.Add("addOnName", addOnName);
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "BeginCreatingAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + (this.Client.Credentials.SubscriptionId != null ? this.Client.Credentials.SubscriptionId.Trim() : "") + "/CloudServices/" + cloudServiceName.Trim() + "/resources/" + parameters.Type.Trim() + "/" + resourceName.Trim() + "/" + addOnName.Trim();
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
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-06-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                XDocument requestDoc = new XDocument();
                
                XElement resourceElement = new XElement(XName.Get("Resource", "http://schemas.microsoft.com/windowsazure"));
                requestDoc.Add(resourceElement);
                
                XElement typeElement = new XElement(XName.Get("Type", "http://schemas.microsoft.com/windowsazure"));
                typeElement.Value = parameters.Type;
                resourceElement.Add(typeElement);
                
                XElement planElement = new XElement(XName.Get("Plan", "http://schemas.microsoft.com/windowsazure"));
                planElement.Value = parameters.Plan;
                resourceElement.Add(planElement);
                
                if (parameters.PromotionCode != null)
                {
                    XElement promotionCodeElement = new XElement(XName.Get("PromotionCode", "http://schemas.microsoft.com/windowsazure"));
                    promotionCodeElement.Value = parameters.PromotionCode;
                    resourceElement.Add(promotionCodeElement);
                }
                
                requestContent = requestDoc.ToString();
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    OperationStatusResponse result = null;
                    result = new OperationStatusResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
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
        /// The Delete Store Item operation deletes Windows Azure Store entries
        /// that re provisioned for a subscription.
        /// </summary>
        /// <param name='cloudServiceName'>
        /// Required. The name of the cloud service to which this store item
        /// will be assigned.
        /// </param>
        /// <param name='resourceProviderNamespace'>
        /// Required. The namespace in which this store item resides.
        /// </param>
        /// <param name='resourceProviderType'>
        /// Required. The type of store item to be deleted.
        /// </param>
        /// <param name='resourceProviderName'>
        /// Required. The name of this resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationStatusResponse> BeginDeletingAsync(string cloudServiceName, string resourceProviderNamespace, string resourceProviderType, string resourceProviderName, CancellationToken cancellationToken)
        {
            // Validate
            if (cloudServiceName == null)
            {
                throw new ArgumentNullException("cloudServiceName");
            }
            if (resourceProviderNamespace == null)
            {
                throw new ArgumentNullException("resourceProviderNamespace");
            }
            if (resourceProviderType == null)
            {
                throw new ArgumentNullException("resourceProviderType");
            }
            if (resourceProviderName == null)
            {
                throw new ArgumentNullException("resourceProviderName");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cloudServiceName", cloudServiceName);
                tracingParameters.Add("resourceProviderNamespace", resourceProviderNamespace);
                tracingParameters.Add("resourceProviderType", resourceProviderType);
                tracingParameters.Add("resourceProviderName", resourceProviderName);
                Tracing.Enter(invocationId, this, "BeginDeletingAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + (this.Client.Credentials.SubscriptionId != null ? this.Client.Credentials.SubscriptionId.Trim() : "") + "/CloudServices/" + cloudServiceName.Trim() + "/resources/" + resourceProviderNamespace.Trim() + "/" + resourceProviderType.Trim() + "/" + resourceProviderName.Trim();
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
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Delete;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-06-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    OperationStatusResponse result = null;
                    result = new OperationStatusResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
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
        /// The Create Store Item operation creates Windows Azure Store entries
        /// in a Windows Azure subscription.
        /// </summary>
        /// <param name='cloudServiceName'>
        /// Required. The name of the cloud service to which this store item
        /// will be assigned.
        /// </param>
        /// <param name='resourceName'>
        /// Required. The name of this resource.
        /// </param>
        /// <param name='addOnName'>
        /// Required. The add on name.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters used to specify how the Create procedure will
        /// function.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationStatusResponse> CreateAsync(string cloudServiceName, string resourceName, string addOnName, AddOnCreateParameters parameters, CancellationToken cancellationToken)
        {
            StoreManagementClient client = this.Client;
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cloudServiceName", cloudServiceName);
                tracingParameters.Add("resourceName", resourceName);
                tracingParameters.Add("addOnName", addOnName);
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "CreateAsync", tracingParameters);
            }
            try
            {
                if (shouldTrace)
                {
                    client = this.Client.WithHandler(new ClientRequestTrackingHandler(invocationId));
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                OperationStatusResponse response = await client.AddOns.BeginCreatingAsync(cloudServiceName, resourceName, addOnName, parameters, cancellationToken).ConfigureAwait(false);
                if (response.Status == OperationStatus.Succeeded)
                {
                    return response;
                }
                cancellationToken.ThrowIfCancellationRequested();
                OperationStatusResponse result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                int delayInSeconds = 30;
                while ((result.Status != OperationStatus.InProgress) == false)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await TaskEx.Delay(delayInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                    result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                    delayInSeconds = 30;
                }
                
                if (shouldTrace)
                {
                    Tracing.Exit(invocationId, result);
                }
                
                if (result.Status != OperationStatus.Succeeded)
                {
                    if (result.Error != null)
                    {
                        CloudException ex = new CloudException(result.Error.Code + " : " + result.Error.Message);
                        ex.ErrorCode = result.Error.Code;
                        ex.ErrorMessage = result.Error.Message;
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    else
                    {
                        CloudException ex = new CloudException("");
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                }
                
                return result;
            }
            finally
            {
                if (client != null && shouldTrace)
                {
                    client.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The Delete Store Item operation deletes Windows Azure Storeentries
        /// that are provisioned for a subscription.
        /// </summary>
        /// <param name='cloudServiceName'>
        /// Required. The name of the cloud service to which this store item
        /// will be assigned.
        /// </param>
        /// <param name='resourceProviderNamespace'>
        /// Required. The namespace in which this store item resides.
        /// </param>
        /// <param name='resourceProviderType'>
        /// Required. The type of store item to be deleted.
        /// </param>
        /// <param name='resourceProviderName'>
        /// Required. The name of this resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationStatusResponse> DeleteAsync(string cloudServiceName, string resourceProviderNamespace, string resourceProviderType, string resourceProviderName, CancellationToken cancellationToken)
        {
            StoreManagementClient client = this.Client;
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cloudServiceName", cloudServiceName);
                tracingParameters.Add("resourceProviderNamespace", resourceProviderNamespace);
                tracingParameters.Add("resourceProviderType", resourceProviderType);
                tracingParameters.Add("resourceProviderName", resourceProviderName);
                Tracing.Enter(invocationId, this, "DeleteAsync", tracingParameters);
            }
            try
            {
                if (shouldTrace)
                {
                    client = this.Client.WithHandler(new ClientRequestTrackingHandler(invocationId));
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                OperationStatusResponse response = await client.AddOns.BeginDeletingAsync(cloudServiceName, resourceProviderNamespace, resourceProviderType, resourceProviderName, cancellationToken).ConfigureAwait(false);
                if (response.Status == OperationStatus.Succeeded)
                {
                    return response;
                }
                cancellationToken.ThrowIfCancellationRequested();
                OperationStatusResponse result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                int delayInSeconds = 30;
                while ((result.Status != OperationStatus.InProgress) == false)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await TaskEx.Delay(delayInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                    result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                    delayInSeconds = 30;
                }
                
                if (shouldTrace)
                {
                    Tracing.Exit(invocationId, result);
                }
                
                if (result.Status != OperationStatus.Succeeded)
                {
                    if (result.Error != null)
                    {
                        CloudException ex = new CloudException(result.Error.Code + " : " + result.Error.Message);
                        ex.ErrorCode = result.Error.Code;
                        ex.ErrorMessage = result.Error.Message;
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    else
                    {
                        CloudException ex = new CloudException("");
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                }
                
                return result;
            }
            finally
            {
                if (client != null && shouldTrace)
                {
                    client.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The Update Store Item operation creates Windows Azure Store entries
        /// in a Windows Azure subscription.
        /// </summary>
        /// <param name='cloudServiceName'>
        /// Required. The name of the cloud service to which this store item
        /// will be assigned.
        /// </param>
        /// <param name='resourceName'>
        /// Required. The name of this resource.
        /// </param>
        /// <param name='addOnName'>
        /// Required. The addon name.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters used to specify how the Create procedure will
        /// function.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationStatusResponse> UpdateAsync(string cloudServiceName, string resourceName, string addOnName, AddOnUpdateParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (cloudServiceName == null)
            {
                throw new ArgumentNullException("cloudServiceName");
            }
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }
            if (addOnName == null)
            {
                throw new ArgumentNullException("addOnName");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (parameters.Plan == null)
            {
                throw new ArgumentNullException("parameters.Plan");
            }
            if (parameters.Type == null)
            {
                throw new ArgumentNullException("parameters.Type");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cloudServiceName", cloudServiceName);
                tracingParameters.Add("resourceName", resourceName);
                tracingParameters.Add("addOnName", addOnName);
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "UpdateAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + (this.Client.Credentials.SubscriptionId != null ? this.Client.Credentials.SubscriptionId.Trim() : "") + "/CloudServices/" + cloudServiceName.Trim() + "/resources/" + parameters.Type.Trim() + "/" + resourceName.Trim() + "/" + addOnName.Trim();
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
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.TryAddWithoutValidation("If-Match", "*");
                httpRequest.Headers.Add("x-ms-version", "2013-06-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                XDocument requestDoc = new XDocument();
                
                XElement resourceElement = new XElement(XName.Get("Resource", "http://schemas.microsoft.com/windowsazure"));
                requestDoc.Add(resourceElement);
                
                XElement typeElement = new XElement(XName.Get("Type", "http://schemas.microsoft.com/windowsazure"));
                typeElement.Value = parameters.Type;
                resourceElement.Add(typeElement);
                
                XElement planElement = new XElement(XName.Get("Plan", "http://schemas.microsoft.com/windowsazure"));
                planElement.Value = parameters.Plan;
                resourceElement.Add(planElement);
                
                if (parameters.PromotionCode != null)
                {
                    XElement promotionCodeElement = new XElement(XName.Get("PromotionCode", "http://schemas.microsoft.com/windowsazure"));
                    promotionCodeElement.Value = parameters.PromotionCode;
                    resourceElement.Add(promotionCodeElement);
                }
                
                requestContent = requestDoc.ToString();
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    OperationStatusResponse result = null;
                    result = new OperationStatusResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
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