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
            var request = new ClassificationRequest
            {
                Examples = new []
                {
                    new [] { "A happy moment", "Positive" },
                    new [] { "I am sad.", "Negative" },
                    new [] { "I am feeling awesome", "Positive" }
                },
                Labels = new []
                {
                    "Positive", "Negative", "Neutral"
                },
                Query = "It is a raining day :(",
                SearchModel = "ada",
                Model = "curie"
            };

            var result = await api.Classifications.CreateClassificationAsync(request);

            Console.WriteLine(result.Label);
        }
    }
}
