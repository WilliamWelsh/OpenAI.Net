namespace OpenAI
{
    public class ClassificationRequestBuilder
    {
        public string Model { get; set; }

        public string Query { get; set; }

        public string[][]? Examples { get; set; }

        public string[]? Labels { get; set; }

        public string? SearchModel { get; set; }

        /// <summary>
        /// ID of the engine to use for completion.
        /// </summary>
        public ClassificationRequestBuilder WithModel(string model)
        {
            Model = model;
            return this;
        }

        /// <summary>
        /// Query to be classified.
        /// </summary>
        public ClassificationRequestBuilder WithQuery(string query)
        {
            Query = query;
            return this;
        }

        /// <summary>
        /// A list of examples with labels
        /// All the label strings will be normalized to be capitalized.
        /// </summary>
        public ClassificationRequestBuilder WithExamples(string[][] examples)
        {
            Examples = examples;
            return this;
        }

        /// <summary>
        /// The set of categories being classified.
        /// If not specified, candidate labels will be
        /// automatically collected from the examples you provide.
        /// All the label strings will be normalized to be capitalized.
        /// </summary>
        public ClassificationRequestBuilder WithLabels(string[] labels)
        {
            Labels = labels;
            return this;
        }

        /// <summary>
        /// ID of the engine to use for Search. Defaults to ada.
        /// </summary>
        public ClassificationRequestBuilder WithSearchModel(string searchModel)
        {
            SearchModel = searchModel;
            return this;
        }

        /// <summary>
        /// Build into a ClassificationRequest
        /// </summary>
        /// <returns></returns>
        public ClassificationRequest Build()
        {
            return new ClassificationRequest(query: Query, model: Model, examples: Examples, labels: Labels, searchModel: SearchModel);
        }
    }
}
