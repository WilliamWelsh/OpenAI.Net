using OpenAI;
using System;
using System.Threading.Tasks;

namespace _01_basic
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            // Initialize the API
            var api = new OpenAIAPI(apiKeys: "YOUR_API_KEY_HERE", engine: Engine.Davinci);

            // Send a request
            var result = await api.Completions.CreateCompletionAsync(prompt: "Once upon a time", max_tokens: 5);

            // Print the result
            Console.WriteLine(result.ToString());
        }
    }
}
