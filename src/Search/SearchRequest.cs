using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI
{
	public class SearchRequest
	{
		/// <summary>
		/// Up to 200 documents to search over, provided as a list of strings.
		/// The maximum document length(in tokens) is 2034 minus the number of tokens in the query.
        /// </summary>
		[JsonProperty("documents")]
		public List<string> Documents { get; set; }

		/// <summary>
		/// Query to search against the documents.
		/// </summary>
		[JsonProperty("query")]
		public string Query { get; set; }

		public SearchRequest(string query = null, params string[] documents)
		{
			Query = query;
			Documents = documents?.ToList() ?? new List<string>();
		}

        public SearchRequest(List<string> documents, string query = null)
        {
            Query = query;
            Documents = documents;
        }

		public SearchRequest(IEnumerable<string> documents)
		{
			Documents = documents.ToList();
		}
	}
}
