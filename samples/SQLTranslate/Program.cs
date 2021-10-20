using OpenAI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLTranslate
{
    class Program
    {
        // This is OpenAI's example of "SQL translate" in OpenAI.NET
        // https://beta.openai.com/examples/default-sql-translate

        // ### Postgres SQL tables, with their properties:
        // #
        // # Employee(id, name, department_id)
        // # Department(id, name, address)
        // # Salary_Payments(id, employee_id, amount, date)
        // #
        // ### A query to list the names of the departments which employed more than 10 employees in the last 3 months
        // SELECT

        // Sample response:
        // DISTINCT department.name 
        // FROM department
        // JOIN employee ON department.id = employee.department_id
        // JOIN salary_payments ON employee.id = salary_payments.employee_id
        // WHERE salary_payments.date > (CURRENT_DATE - INTERVAL '3 months')
        // GROUP BY department.name
        // HAVING COUNT(employee.id) > 10;

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        // THIS IS UNTESTED. I don't have access to the codex. If someone with access could test, that would be great. :)

        public async Task MainAsync()
        {
            // Initialize the API
            var api = new OpenAIAPI(apiKeys: "YOUR_API_KEY_HERE", engine: Engine.DavinciCodex);

            // Set up the  request
            var request = new CompletionRequestBuilder()
                .WithPrompt("Convert my short hand into a first-hand account of the meeting:\n\nTom: Profits up 50%\nJane: New servers are online\nKjel: Need more time to fix software\nJane: Happy to help\nParkman: Beta testing almost done\n\nSummary:")
                .WithTemperature(0)
                .WithMaxTokens(150)
                .WithTopP(1)
                .WithFrequencyPenalty(0.0)
                .WithPresencePenalty(0.0)
                .WithStop(new List<string> { "#", ";" })
                .Build();

            var result = await api.Completions.CreateCompletionAsync(request);

            Console.WriteLine(result.ToString());

            // THIS IS UNTESTED. I don't have access to the codex. If someone with access could test, that would be great. :)
        }
    }
}
