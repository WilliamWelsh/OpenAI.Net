using OpenAI;
using System;
using System.Threading.Tasks;

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
                .WithExamples(new []
                {
                    new [] { "A happy moment", "Positive" },
                    new [] { "I am sad.", "Negative" },
                    new [] { "I am feeling awesome", "Positive" }
                })
                .WithLabels(new []
                {
                    "Positive", "Negative", "Neutral"
                })
                .WithQuery("It is a raining day :(")
                .WithSearchModel("ada")
                .WithModel("curie")
                .Build();

            var result = await api.Classifications.CreateClassificationAsync(request);

            Console.WriteLine(result.Label);

            // Should print "Negative"
        }
    }
}
