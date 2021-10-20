using OpenAI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _03_Classifications
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            // Initialize the API
            var api = new OpenAIAPI(apiKeys: "YOUR_API_KEY_HERE", engine: Engine.Davinci);

            // Set up a Classifications request
            // https://beta.openai.com/docs/api-reference/classifications
            var request = new ClassificationRequestBuilder()
                .WithExamples(new List<List<string>>
                {
                    new List<string> { "A happy moment", "Positive" },
                    new List<string> { "I am sad.", "Negative" },
                    new List<string> { "I am feeling awesome", "Positive" }
                })
                .WithLabels(new List<string>
                {
                    "Positive", "Negative", "Neutral"
                })
                .WithQuery("It is a raining day :(")
                .WithSearchModel(Engine.Ada)
                .WithModel(Engine.Curie)
                .Build();

            var result = await api.Classifications.CreateClassificationAsync(request);

            Console.WriteLine(result.Label);

            // Should print "Negative"
        }
    }
}
