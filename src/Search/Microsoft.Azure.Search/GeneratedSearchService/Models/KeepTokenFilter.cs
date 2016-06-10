// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// A token filter that only keeps tokens with text contained in a
    /// specified list of words.
    /// </summary>
    [JsonObject("#Microsoft.Azure.Search.KeepTokenFilter")]
    public partial class KeepTokenFilter : TokenFilter
    {
        /// <summary>
        /// Initializes a new instance of the KeepTokenFilter class.
        /// </summary>
        public KeepTokenFilter() { }

        /// <summary>
        /// Initializes a new instance of the KeepTokenFilter class.
        /// </summary>
        public KeepTokenFilter(string name, IList<string> keepWords, bool? lowerCaseKeepWords = default(bool?))
            : base(name)
        {
            KeepWords = keepWords;
            LowerCaseKeepWords = lowerCaseKeepWords;
        }

        /// <summary>
        /// Gets or sets the list of words to keep.
        /// </summary>
        [JsonProperty(PropertyName = "keepWords")]
        public IList<string> KeepWords { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to lower case all words
        /// first. Default is false.
        /// </summary>
        [JsonProperty(PropertyName = "keepWordsCase")]
        public bool? LowerCaseKeepWords { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (KeepWords == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "KeepWords");
            }
        }
    }
}
