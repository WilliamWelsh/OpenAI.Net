using System.Collections.Generic;

namespace OpenAI
{
    public class AnswerRequestBuilder
    {
        public Engine Model { get; set; }

        public string Question { get; set; }

        public List<List<string>> Examples { get; set; }

        public string ExamplesContext { get; set; }

        public List<string>? Documents { get; set; }

        public Engine? SearchModel { get; set; }

        public double? Temperature { get; set; }

        public int? MaxTokens { get; set; }

        public List<string>? Stop { get; set; }

        /// <summary>
        /// ID of the engine to use for completion. Defaults to ada.
        /// </summary>
        public AnswerRequestBuilder WithModel(Engine model)
        {
            Model = model;
            return this;
        }

        /// <summary>
        /// The question to get answered.
        /// </summary>
        public AnswerRequestBuilder WithQuestion(string question)
        {
            Question = question;
            return this;
        }

        /// <summary>
        /// List of (question, answer) pairs that will help steer the model towards
        /// the tone and answer format you'd like. OpenAI recommends adding 2 to 3 examples.
        /// </summary>
        public AnswerRequestBuilder WithExamples(List<List<string>> examples)
        {
            Examples = examples;
            return this;
        }

        /// <summary>
        /// A text snippet containing the contextual information used to generate the answers for the examples you provide.
        /// </summary>
        public AnswerRequestBuilder WithExamplesContext(string examplesContext)
        {
            ExamplesContext = examplesContext;
            return this;
        }

        /// <summary>
        /// List of documents from which the answer for input question should be derived.
        /// If this is an empty list, the question will be answered based
        /// on the question-answer examples.
        /// </summary>
        public AnswerRequestBuilder WithDocuments(List<string> documents)
        {
            Documents = documents;
            return this;
        }

        /// <summary>
        /// ID of the engine to use for Search.
        /// </summary>
        public AnswerRequestBuilder WithSearchModel(Engine searchModel)
        {
            SearchModel = searchModel;
            return this;
        }

        /// <summary>
        /// What sampling temperature to use.
        /// Higher values mean the model will take more risks
        /// and value 0 (argmax sampling) works better for scenarios with a well-defined answer.
        /// </summary>
        public AnswerRequestBuilder WithTemperature(double temperature)
        {
            Temperature = temperature;
            return this;
        }

        /// <summary>
        /// The maximum number of tokens allowed for the generated answer.
        /// </summary>
        public AnswerRequestBuilder WithMaxTokens(int maxTokens)
        {
            MaxTokens = maxTokens;
            return this;
        }

        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
        /// </summary>
        public AnswerRequestBuilder WithStop(List<string> stop)
        {
            Stop = stop;
            return this;
        }

        /// <summary>
        /// Build into a AnswerRequest
        /// </summary>
        /// <returns></returns>
        public AnswerRequest Build()
        {
            return new AnswerRequest(model: Model, question: Question, examples: Examples, examplesContext: ExamplesContext, documents: Documents, searchModel: SearchModel, temperature: Temperature, maxTokens: MaxTokens, stop: Stop);
        }
    }
}
