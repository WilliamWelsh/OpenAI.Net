using OpenAI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NotesToSummary
{
    class Program
    {
        // This is OpenAI's example of "Notes to summary" in OpenAI.NET
        // https://beta.openai.com/examples/default-notes-summary

        // Prompt:
        // Convert my short hand into a first-hand account of the meeting:
        // 
        // Tom: Profits up 50%
        // Jane: New servers are online
        // Kjel: Need more time to fix software
        // Jane: Happy to help
        // Parkman: Beta testing almost done
        // 
        // Summary:

        // Sample response:
        // Profits are up, Jane's new servers are online, Kjel needs more time to fix software, and Parkman's beta testing is almost done.

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            // Initialize the API
            var api = new OpenAIAPI(apiKeys: "YOUR_API_KEY_HERE", engine: Engine.DavinciInstructBeta);

            // Set up the  request
            var request = new CompletionRequestBuilder()
                .WithPrompt("Convert my short hand into a first-hand account of the meeting:\n\nTom: Profits up 50%\nJane: New servers are online\nKjel: Need more time to fix software\nJane: Happy to help\nParkman: Beta testing almost done\n\nSummary:")
                .WithTemperature(0.7)
                .WithMaxTokens(64)
                .WithTopP(1)
                .WithFrequencyPenalty(0.0)
                .WithPresencePenalty(0.0)
                .Build();

            var result = await api.Completions.CreateCompletionAsync(request);

            Console.WriteLine(result.ToString());

            // Should print something like "Profits are up, Jane's new servers are online, Kjel needs more time to fix software, and Parkman's beta testing is almost done."
        }
    }
}
