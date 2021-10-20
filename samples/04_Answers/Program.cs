using OpenAI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _04_Answers
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
            var request = new AnswerRequestBuilder()
                .WithDocuments(new List<string>
                {
                    "Puppy A is happy.", "Puppy B is sad."
                })
                .WithQuestion("which puppy is happy?")
                .WithSearchModel(Engine.Ada)
                .WithModel(Engine.Curie)
                .WithExamplesContext("In 2017, U.S. life expectancy was 78.6 years.")
                .WithExamples(new List<List<string>>
                {
                    new List<string> { "What is human life expectancy in the United States?", "78 years." }
                })
                .WithMaxTokens(5)
                .WithStop(new List<string>
                {
                    "\n", "<|endoftext|>"
                })
                .Build();

            // Send the request & get the best match
            // To get the score of the result, use GetBestMatchWithScoreAsync(request)
            var result = await api.Answers.CreateAnswerAsync(request);

            // Print the result
            Console.WriteLine(result.Answers[0]);

            // Should print something like "puppy A."
        }
    }
}
