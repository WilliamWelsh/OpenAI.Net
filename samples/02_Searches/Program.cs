using OpenAI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _02_Searches
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            // Initialize the API
            var api = new OpenAIAPI(apiKeys: "YOUR_API_KEY_HERE", engine: Engine.Davinci);

            // Set up a search request
            // https://beta.openai.com/docs/api-reference/searches
            var request = new SearchRequestBuilder()
                .WithQuery("the president")
                .WithDocuments(new List<string>
                {
                    "White House",
                    "hospital",
                    "school"
                })
                .Build();


            // Send the request & get the best match
            // To get the score of the result, use GetBestMatchWithScoreAsync(request)
            var result = await api.Search.GetBestMatchAsync(request);

            // Print the result
            Console.WriteLine(result);

            // Should print "White House"
        }
    }
}
