using System.Collections.Generic;

namespace OpenAI
{
    public class SearchRequestBuilder
    {
        public List<string> Documents { get; set; }

        public string Query { get; set; }

        /// <summary>
        /// Up to 200 documents to search over, provided as a list of strings.
        /// The maximum document length(in tokens) is 2034 minus the number of tokens in the query.
        /// </summary>
        public SearchRequestBuilder WithDocuments(List<string> documents)
        {
            Documents = documents;
            return this;
        }

        /// <summary>
        /// Up to 200 documents to search over, provided as a list of strings.
        /// The maximum document length(in tokens) is 2034 minus the number of tokens in the query.
        /// </summary>
        public SearchRequestBuilder WithQuery(string query)
        {
            Query = query;
            return this;
        }

        /// <summary>
        /// Build into a SearchRequest
        /// </summary>
        /// <returns></returns>
        public SearchRequest Build()
        {
            return new SearchRequest(query: Query, documents: Documents);
        }
    }
}
