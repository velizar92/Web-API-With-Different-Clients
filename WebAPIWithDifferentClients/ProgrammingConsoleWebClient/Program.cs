using ProgrammingConsoleWebClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProgrammingConsoleWebClient
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            client.DefaultRequestHeaders.Accept.Clear();

            IEnumerable<ProgrammingLanguage> languages 
                = await GetResource("https://localhost:7046/api/ProgrammingLanguages/all");

            foreach (var language in languages)
            {
                Console.WriteLine(language.Name);
                Console.WriteLine(language.Description);
                Console.WriteLine("======Tutorials:======");

                foreach (var tutorial in language.Tutorials)
                {
                    Console.WriteLine(tutorial.Name);
                    Console.WriteLine(tutorial.Description);
                }
            }
        }

        static async Task<IEnumerable<ProgrammingLanguage>> GetResource(string resourceUrl)
        {
            var streamTask = client.GetStreamAsync(resourceUrl);
            var languages = await JsonSerializer.DeserializeAsync<List<ProgrammingLanguage>>(await streamTask);

            return languages;
        }
    }
}
