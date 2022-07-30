namespace ProgrammingConsoleWebClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using OfficeOpenXml;
    using ProgrammingConsoleWebClient.ViewModels;
  
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            client.DefaultRequestHeaders.Accept.Clear();

            //ProgrammingLanguage programmingLanguage = new ProgrammingLanguage()
            //{
            //    Name = "Python",
            //    Description = "Python is cool language.",
            //    Tutorials = new List<Tutorial>()               
            //};

            //await CreateResource("https://localhost:7046/api/ProgrammingLanguages/create", programmingLanguage);

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

        static async Task CreateResource(string resourceUrl, ProgrammingLanguage programmingLanguage)
        {
            string jsonPayload = JsonSerializer.Serialize<ProgrammingLanguage>(programmingLanguage);

            StringContent httpContent = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(resourceUrl, httpContent);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
    }
}
