using Newtonsoft.Json;

namespace OpenAI
{
    /// <summary>
    /// The documents used
    /// </summary>
    public class SelectedDocument
    {
        /// <summary>
        /// The document index
        /// </summary>
        [JsonProperty("document")]
        public string Document { get; set; }

        /// <summary>
        /// The text of the document
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// Represents an answer choice returned by the Answers API
    /// </summary>
    public class AnswerResult
    {
        /// <summary>
        /// The answers returned
        /// </summary>
        [JsonProperty("answers")]
        public string[] Answers { get; set; }

        [JsonProperty("completion")]
        public string Completion { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("search_model")]
        public string SearchModel { get; set; }

        [JsonProperty("selected_documents")]
        public SelectedDocument[] SelectedDocuments { get; set; }
        
        // TODO : Add ToString() override
    }
}
