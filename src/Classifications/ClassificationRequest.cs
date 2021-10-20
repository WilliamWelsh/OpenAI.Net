using Newtonsoft.Json;

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
        public string[][] Examples { get; set; }

        /// <summary>
        /// The set of categories being classified.
        /// If not specified, candidate labels will be
        /// automatically collected from the examples you provide.
        /// All the label strings will be normalized to be capitalized.
        /// </summary>
        [JsonProperty("labels")]
        public string[] Labels { get; set; }

        /// <summary>
        /// Query to be classified.
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// ID of the engine to use for Search.
        /// </summary>
        [JsonProperty("search_model")]
        public string SearchModel { get; set; }

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
