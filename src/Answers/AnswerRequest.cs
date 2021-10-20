using Newtonsoft.Json;

namespace OpenAI
{
    /// <summary>
    /// Represents a request to the Completions API.  Mostly matches the parameters in <see href="https://beta.openai.com/docs/api-reference/answers">the OpenAI docs</see>.
    /// </summary>
    public class AnswerRequest
    {
        /// <summary>
        /// ID of the engine to use for completion. Defaults to ada.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// The question to get answered.
        /// </summary>
        [JsonProperty("question")]
        public string Question { get; set; }

        /// <summary>
        /// List of (question, answer) pairs that will help steer the model towards
        /// the tone and answer format you'd like. OpenAI recommends adding 2 to 3 examples.
        /// </summary>
        [JsonProperty("examples")]
        public string[][] Examples { get; set; }

        /// <summary>
        /// A text snippet containing the contextual information used to generate the answers for the examples you provide.
        /// </summary>
        [JsonProperty("examples_context")]
        public string ExamplesContext { get; set; }

        /// <summary>
        /// List of documents from which the answer for input question should be derived.
        /// If this is an empty list, the question will be answered based
        /// on the question-answer examples.
        /// </summary>
        [JsonProperty("documents")]
        public string[] Documents { get; set; }

        /// <summary>
        /// ID of the engine to use for Search.
        /// </summary>
        [JsonProperty("search_model")]
        public string SearchModel { get; set; }

        /// <summary>
        /// What sampling temperature to use.
        /// Higher values mean the model will take more risks
        /// and value 0 (argmax sampling) works better for scenarios with a well-defined answer.
        /// </summary>
        [JsonProperty("temperature")]
        public double? Temperature { get; set; }

        /// <summary>
        /// The maximum number of tokens allowed for the generated answer.
        /// </summary>
        [JsonProperty("max_tokens")]
        public long MaxTokens { get; set; }

        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
        /// </summary>
        [JsonProperty("stop")]
        public string[] Stop { get; set; }

        /// <summary>
        /// Creates a new, empty <see cref="AnswerRequest"/>
        /// </summary>
        public AnswerRequest()
        {
            Model = "curie";
            Stop = new [] { "\n", "<|endoftext|>" };
        }

        public AnswerRequest(string question, string[][] examples, string examplesContext)
        {
            Model = "curie";
            Question = question;
            Examples = examples;
            ExamplesContext = examplesContext;
            Stop = new [] { "\n", "<|endoftext|>" };
        }

        public AnswerRequest(AnswerRequest basedOn)
        {
            this.Documents = basedOn.Documents;
            this.Question = basedOn.Question;
            this.SearchModel = basedOn.SearchModel;
            this.Model = basedOn.Model;
            this.ExamplesContext = basedOn.ExamplesContext;
            this.Examples = basedOn.Examples;
            this.MaxTokens = basedOn.MaxTokens;
            this.Stop = basedOn.Stop;
            this.Temperature = basedOn.Temperature;
        }
    }
}
