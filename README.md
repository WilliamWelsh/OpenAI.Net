# OpenAI.Net

An unofficial .NET API wrapper for OpenAI. Originally forked from [OpenAI-API-dotnet](https://github.com/OkGoDoIt/OpenAI-API-dotnet).  

## Examples

```csharp
var api = new OpenAI_API.OpenAIAPI(engine: Engine.Davinci);

var result = await api.Completions.CreateCompletionAsync("One Two Three One Two", temperature: 0.1);
Console.WriteLine(result.ToString());
// should print something starting with "Three"
```

```csharp
var api = new OpenAI_API.OpenAIAPI("sk-myapikeyhere"););

var result = await api.Search.GetBestMatchAsync("Washington DC", "Canada", "China", "USA", "Spain");
Console.WriteLine(result);
// should print "USA"
```

### Authentication
There are 3 ways to provide your API keys, in order of precedence:
1.  Pass keys directly to `APIAuthentication(string key)` constructor
2.  Set environment var for OPENAI_KEY
3.  Include a config file in the local directory or in your user directory named `.openai` and containing the line:
```shell
OPENAI_KEY=sk-aaaabbbbbccccddddd
```

You use the `APIAuthentication` when you initialize the API as shown:
```csharp
// for example
OpenAIAPI api = new OpenAIAPI("sk-mykeyhere"); // shorthand
// or
OpenAIAPI api = new OpenAIAPI(new APIAuthentication("sk-secretkey")); // create object manually
// or
OpenAIAPI api = new OpenAIAPI(APIAuthentication LoadFromEnv()); // use env vars
// or
OpenAIAPI api = new OpenAIAPI(APIAuthentication LoadFromPath()); // use config file (can optionally specify where to look)
// or
OpenAIAPI api = new OpenAIAPI(); // uses default, env, or config file
```

### Completions
The Completion API is accessed via `OpenAIAPI.Completions`:

```csharp
CreateCompletionAsync(CompletionRequest request)

// for example
var result = await api.Completions.CreateCompletionAsync(new CompletionRequest("One Two Three One Two", temperature: 0.1));
// or
var result = await api.Completions.CreateCompletionAsync("One Two Three One Two", temperature: 0.1);
// or other convenience overloads
```
You can create your `CompletionRequest` ahead of time or use one of the helper overloads for convenience.  It returns a `CompletionResult` which is mostly metadata, so use its `.ToString()` method to get the text if all you want is the completion.

#### Streaming
Streaming allows you to get results are they are generated, which can help your application feel more responsive, especially on slow models like Davinci.

Using the new C# 8.0 async iterators:
```csharp
IAsyncEnumerable<CompletionResult> StreamCompletionEnumerableAsync(CompletionRequest request)

// for example
await foreach (var token in api.Completions.StreamCompletionEnumerableAsync(new CompletionRequest("My name is Roger and I am a principal software engineer at Salesforce.  This is my resume:", 200, 0.5, presencePenalty: 0.1, frequencyPenalty: 0.1)))
{
	Console.Write(token);
}
```

Or if using .NET framework or C# <8.0:
```csharp
StreamCompletionAsync(CompletionRequest request, Action<CompletionResult> resultHandler)

// for example
await api.Completions.StreamCompletionAsync(
	new CompletionRequest("My name is Roger and I am a principal software engineer at Salesforce.  This is my resume:", 200, 0.5, presencePenalty: 0.1, frequencyPenalty: 0.1),
	res => ResumeTextbox.Text += res.ToString());
```

### Document Search
The Search API is accessed via `OpenAIAPI.Search`:

You can get all results as a dictionary using
```csharp
GetSearchResultsAsync(SearchRequest request)

// for example
var request = new SearchRequest()
{
	Query = "Washington DC",
	Documents = new List<string> { "Canada", "China", "USA", "Spain" }
};
var result = await api.Search.GetSearchResultsAsync(request);
// result["USA"] == 294.22
// result["Spain"] == 73.81
```

The returned dictionary maps documents to scores.  You can create your `SearchRequest` ahead of time or use one of the helper overloads for convenience, such as
```csharp
GetSearchResultsAsync(string query, params string[] documents)

// for example
var result = await api.Search.GetSearchResultsAsync("Washington DC", "Canada", "China", "USA", "Spain");
```

You can get only the best match using
```csharp
GetBestMatchAsync(request)
```

And if you only want the best match but still want to know the score, use
```csharp
GetBestMatchWithScoreAsync(request)
```
Each of those methods has similar convenience overloads to specify the request inline.

### Finetuning
I don't yet have access to finetuning, but once I do I will add it to this SDK.  Subscribe to this repo if you want to be alerted.


## Documentation

Every single class, method, and property has extensive XML documentation, so it should show up automatically in IntelliSense.  That combined with the official OpenAI documentation should be enough to get started.  Feel free to add me on Discord Reverse#0069 if you have any questions.  Better documentation may come later.