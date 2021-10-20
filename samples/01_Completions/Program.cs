using OpenAI;
using System;
using System.Threading.Tasks;

namespace _01_Completions
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            // Initialize the API
            var api = new OpenAIAPI(apiKeys: "YOUR_API_KEY_HERE", engine: Engine.Davinci);

            // Set up a search request
            // https://beta.openai.com/docs/api-reference/completions
            var request = new CompletionRequestBuilder()
                .WithPrompt("Once upon a time")
                .WithMaxTokens(5)
                .Build();

            var result = await api.Completions.CreateCompletionAsync(request);

            // Print the result
            Console.WriteLine(result.ToString());

            // Should print something like ", there was a girl who"
        }
    }
}
