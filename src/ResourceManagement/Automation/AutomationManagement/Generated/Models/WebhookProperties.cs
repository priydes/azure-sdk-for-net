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
using Hyak.Common;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Management.Automation.Models
{
    /// <summary>
    /// Definition of the webhook properties
    /// </summary>
    public partial class WebhookProperties : ResourceCommonPropertiesBase
    {
        private DateTimeOffset _expiryTime;
        
        /// <summary>
        /// Optional. Gets or sets the expiry time.
        /// </summary>
        public DateTimeOffset ExpiryTime
        {
            get { return this._expiryTime; }
            set { this._expiryTime = value; }
        }
        
        private bool _isEnabled;
        
        /// <summary>
        /// Optional. Gets or sets the value of the enabled flag of the webhook.
        /// </summary>
        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set { this._isEnabled = value; }
        }
        
        private System.DateTimeOffset? _lastInvokedTime;
        
        /// <summary>
        /// Optional. Gets or sets the last invoked time.
        /// </summary>
        public System.DateTimeOffset? LastInvokedTime
        {
            get { return this._lastInvokedTime; }
            set { this._lastInvokedTime = value; }
        }
        
        private IDictionary<string, string> _parameters;
        
        /// <summary>
        /// Optional. Gets or sets the parameters of the job that is created
        /// when the webhook calls the runbook it is associated with.
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get { return this._parameters; }
            set { this._parameters = value; }
        }
        
        private RunbookAssociationProperty _runbook;
        
        /// <summary>
        /// Optional. Gets or sets the runbook the webhook is associated with.
        /// </summary>
        public RunbookAssociationProperty Runbook
        {
            get { return this._runbook; }
            set { this._runbook = value; }
        }
        
        private string _runOn;
        
        /// <summary>
        /// Optional. Gets or sets the name of the hybrid worker group the
        /// webhook job will run on.
        /// </summary>
        public string RunOn
        {
            get { return this._runOn; }
            set { this._runOn = value; }
        }
        
        private string _uri;
        
        /// <summary>
        /// Optional. Gets or sets the webhook uri.
        /// </summary>
        public string Uri
        {
            get { return this._uri; }
            set { this._uri = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the WebhookProperties class.
        /// </summary>
        public WebhookProperties()
        {
            this.Parameters = new LazyDictionary<string, string>();
        }
    }
}
