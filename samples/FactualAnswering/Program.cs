using OpenAI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FactualAnswering
{
    class Program
    {
        // This is OpenAI's example of "Factual answering" in OpenAI.NET
        // https://beta.openai.com/examples/default-factual-answering

        // Prompt:
        // Q: Who is Batman?
        // A: Batman is a fictional comic book character.
        // ###
        // Q: What is torsalplexity?
        // A: ?
        // ###
        // Q: What is Devz9?
        // A: ?
        // ###
        // Q: Who is George Lucas?
        // A: George Lucas is American film director and producer famous for creating Star Wars.
        // ###
        // Q: What is the capital of California?
        // A: Sacramento.
        // ###
        // Q: What orbits the Earth?
        // A: The Moon.
        // ###
        // Q: Who is Fred Rickerson?
        // A: ?
        // ###
        // Q: What is an atom?
        // A: An atom is a tiny particle that makes up everything.
        // ###
        // Q: Who is Alvan Muntz?
        // A: ?
        // ###
        // Q: What is Kozar-09?
        // A: ?
        // ###
        // Q: How many moons does Mars have?
        // A: Two, Phobos and Deimos.
        // ###
        // Q: What's a language model?
        // A:

        // Sample response:
        // A language model is a statistical model that describes the probability of a word given a context.

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            // Initialize the API
            var api = new OpenAIAPI(apiKeys: "YOUR_API_KEY_HERE", engine: Engine.Davinci);

            // Set up the  request
            var request = new CompletionRequestBuilder()
                .WithPrompt("Q: Who is Batman?\nA: Batman is a fictional comic book character.\n###\nQ: What is torsalplexity?\nA: ?\n###\nQ: What is Devz9?\nA: ?\n###\nQ: Who is George Lucas?\nA: George Lucas is American film director and producer famous for creating Star Wars.\n###\nQ: What is the capital of California?\nA: Sacramento.\n###\nQ: What orbits the Earth?\nA: The Moon.\n###\nQ: Who is Fred Rickerson?\nA: ?\n###\nQ: What is an atom?\nA: An atom is a tiny particle that makes up everything.\n###\nQ: Who is Alvan Muntz?\nA: ?\n###\nQ: What is Kozar-09?\nA: ?\n###\nQ: How many moons does Mars have?\nA: Two, Phobos and Deimos.\n###\nQ: What's a language model?\nA:")
                .WithTemperature(0)
                .WithMaxTokens(60)
                .WithTopP(1)
                .WithFrequencyPenalty(0.0)
                .WithPresencePenalty(0.0)
                .WithStop(new List<string> { "###" })
                .Build();

            var result = await api.Completions.CreateCompletionAsync(request);

            Console.WriteLine(result.ToString());

            // Should print something like "A language model is a statistical model that describes the probability of a word given a context."
        }
    }
}
