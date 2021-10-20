using OpenAI;
using System;
using System.Threading.Tasks;

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
            var request = new AnswerRequest
            {
                Question = "which puppy is happy?",
                Examples = new[]
                {
                    new [] { "What is human life expectancy in the United States?", "78 years." }
                },
                ExamplesContext = "In 2017, U.S. life expectancy was 78.6 years.",
                Documents = new []
                {
                    "Puppy A is happy.",
                    "Puppy B is sad."
                },
                MaxTokens = 5
            };

            // Send the request & get the best match
            // To get the score of the result, use GetBestMatchWithScoreAsync(request)
            var result = await api.Answers.CreateAnswerAsync(request);

            // Print the result
            Console.WriteLine(result.Answers[0]);
        }
    }
}
