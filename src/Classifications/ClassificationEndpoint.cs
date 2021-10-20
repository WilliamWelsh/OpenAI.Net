using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenAI
{
    /// <summary>
    /// Given a query and a set of labeled examples, the model will
    /// predict the most likely label for the query. Useful as a drop-in
    /// replacement for any ML classification or text-to-label task.
    /// </summary>
    public class ClassificationEndpoint
    {
        private OpenAIAPI Api;

        internal  ClassificationEndpoint(OpenAIAPI api)
        {
            Api = api;
        }

        public async Task<ClassificationResult> CreateClassificationAsync(ClassificationRequest request)
        {
            if (Api.Auth?.ApiKey is null)
            {
                throw new AuthenticationException("You must provide API authentication.  Please refer to https://github.com/WilliamWelsh/OpenAI.Net#authentication for details.");
            }

            //request.Stream = false;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Api.Auth.ApiKey);
            client.DefaultRequestHeaders.Add("User-Agent", "williamwelsh/openai-dotnet");

            var jsonContent = JsonConvert.SerializeObject(request, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/classifications", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var resultAsString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ClassificationResult>(resultAsString);
            }

            throw new HttpRequestException("Error calling OpenAi API to get completion.  HTTP status code: " + response.StatusCode + ". Request body: " + jsonContent);
        }
    }
}
