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
        private static readonly HttpClient _client = new HttpClient();
        static async Task Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ConsoleLogger consoleLogger = new ConsoleLogger();
            HttpWebClient webClient = new HttpWebClient(consoleLogger);

            //ProgrammingLanguage programmingLanguage = new ProgrammingLanguage()
            //{
            //    Name = "Python",
            //    Description = "Python is cool language.",
            //    Tutorials = new List<Tutorial>()
            //};

            //await CreateResource("https://localhost:7046/api/ProgrammingLanguages/create", programmingLanguage);

            //await webClient.DeleteResource("https://localhost:7046/api/ProgrammingLanguages/delete/19");

            IEnumerable<ProgrammingLanguage> languages
                = await webClient.GetResource("https://localhost:7046/api/ProgrammingLanguages/all");

            foreach (var language in languages)
            {
                Console.WriteLine(language.Id);
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

    }
}
