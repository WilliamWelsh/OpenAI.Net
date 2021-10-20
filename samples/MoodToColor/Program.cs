using OpenAI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MoodToColor
{
    class Program
    {
        // This is OpenAI's example of "Mood to color" in OpenAI.NET
        // https://beta.openai.com/examples/default-mood-color

        // Prompt:
        // The CSS code for a color like a blue sky at dusk:
        // 
        // background-color: #

        // Sample response:
        // 6b8ecc

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            // Initialize the API
            var api = new OpenAIAPI(apiKeys: "YOUR_API_KEY_HERE", engine: Engine.Davinci);

            // Set up the  request
            var request = new CompletionRequestBuilder()
                .WithPrompt("The CSS code for a color like a blue sky at dusk:\n\nbackground-color: #")
                .WithTemperature(0)
                .WithMaxTokens(64)
                .WithTopP(1)
                .WithFrequencyPenalty(0.0)
                .WithPresencePenalty(0.0)
                .WithStop(new List<string> { ";" })
                .Build();

            var result = await api.Completions.CreateCompletionAsync(request);

            Console.WriteLine(result.ToString());

            // Should print something like "6b8ecc"
        }
    }
}
