using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenAI
{
    /// <summary>
    /// Represents a request to the Classifications API.  Mostly matches the parameters in <see href="https://beta.openai.com/docs/api-reference/classifications">the OpenAI docs</see>.
    /// </summary>
    public class ClassificationRequest
    {
        /// <summary>
        /// A list of examples with labels
        /// All the label strings will be normalized to be capitalized.
        /// </summary>
        [JsonProperty("examples")]
        public List<List<string>>? Examples { get; set; }

        /// <summary>
        /// The set of categories being classified.
        /// If not specified, candidate labels will be
        /// automatically collected from the examples you provide.
        /// All the label strings will be normalized to be capitalized.
        /// </summary>
        [JsonProperty("labels")]
        public List<string>? Labels { get; set; }

        /// <summary>
        /// Query to be classified.
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// ID of the engine to use for Search. Defaults to ada.
        /// </summary>
        [JsonProperty("search_model")]
        public string? SearchModel { get; set; }

        /// <summary>
        /// ID of the engine to use for completion.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Creates a new, empty <see cref="ClassificationRequest"/>
        /// </summary>
        public ClassificationRequest()
        {
            
        }

        /// <summary>
        /// Creates a new <see cref="ClassificationRequest"/> with the specified parameters
        /// </summary>
        public ClassificationRequest(string query, Engine model, List<List<string>>? examples = null, List<string>? labels = null, Engine? searchModel = null)
        {
            this.Query = query;
            this.Model = model;
            this.Examples = examples;
            this.Labels = labels;
            this.SearchModel = searchModel;
        }

        public ClassificationRequest(ClassificationRequest basedOn)
        {
            this.Examples = basedOn.Examples;
            this.Labels = basedOn.Labels;
            this.Query = basedOn.Query;
            this.SearchModel = basedOn.SearchModel;
            this.Model = basedOn.Model;
        }
    }
}
