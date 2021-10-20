using Newtonsoft.Json;

namespace OpenAI
{
    public class SelectedExample
    {
        [JsonProperty("document")]
        public long Document { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// Represents a Classification response
    /// </summary>
    public class ClassificationResult
    {
        [JsonProperty("completion")]
        public string Completion { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// ID of the engine used for completion.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// ID of the engine used for Search.
        /// </summary>
        [JsonProperty("search_model")]
        public string SearchModel { get; set; }

        [JsonProperty("selected_examples")]
        public SelectedExample[] SelectedExamples { get; set; }
    }
}
