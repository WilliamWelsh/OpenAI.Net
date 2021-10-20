using OpenAI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MovieToEmoji
{
    class Program
    {
        // This is OpenAI's example of "Movie to Emoji" in OpenAI.NET
        // https://beta.openai.com/examples/default-movie-to-emoji

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            // Initialize the API
            var api = new OpenAIAPI(apiKeys: "YOUR_API_KEY_HERE", engine: Engine.Davinci);

            // Set up the  request
            var request = new CompletionRequestBuilder()
                .WithPrompt("Back to Future: 👨👴🚗🕒\nBatman: 🤵🦇\nTransformers: 🚗🤖\nWonder Woman: 👸🏻👸🏼👸🏽👸🏾👸🏿\nWinnie the Pooh: 🐻🐼🐻\nThe Godfather: 👨👩👧🕵🏻‍♂️👲💥\nGame of Thrones: 🏹🗡🗡🏹\nSpider-Man:")
                .WithTemperature(0.8)
                .WithMaxTokens(60)
                .WithTopP(1)
                .WithFrequencyPenalty(0.0)
                .WithPresencePenalty(0.0)
                .WithStop(new List<string> { "\n" })
                .Build();

            var result = await api.Completions.CreateCompletionAsync(request);

            foreach (var choice in result.Completions)
                Console.WriteLine(choice.Text);

            // Should print something like three spider emojis, I got 1 web and 2 spider emojis
            // " 🕸🕷🕷"
            // Be aware your console output might not support emojis and may come up as "???"
        }
    }
}
