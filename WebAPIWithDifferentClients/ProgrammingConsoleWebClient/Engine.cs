namespace ProgrammingConsoleWebClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ConsoleTables;
    using OfficeOpenXml;
    using ProgrammingConsoleWebClient.ViewModels;

    public class Engine
    {
        private readonly IHttpWebClient _webClient;
        private readonly ILogger _logger;

        public Engine(IHttpWebClient webClient, ILogger logger)
        {
            _logger = logger;
            _webClient = webClient;
        }

        public async Task Run()
        {
            int id = 0;
            ProgrammingLanguage language = null;
            IEnumerable<ProgrammingLanguage> languages = new List<ProgrammingLanguage>();

            ShowMenu();

            Console.WriteLine("Please choose your option: ");
            int optionNumber = int.Parse(Console.ReadLine());

            while (true)
            {
                switch (optionNumber)
                {
                    case 1:
                        language = CreateLocalResource();
                        await _webClient.CreateResource("https://localhost:7046/api/ProgrammingLanguages/create", language);
                        languages = await _webClient.GetResources("https://localhost:7046/api/ProgrammingLanguages/all");
                        WebDataViewer.PrintLanguages(languages);
                        languages.ToList().Clear();
                        break;
                    case 2:
                        languages = await _webClient.GetResources("https://localhost:7046/api/ProgrammingLanguages/all");
                        WebDataViewer.PrintLanguages(languages);
                        languages.ToList().Clear();
                        break;
                    case 3:
                        languages = await _webClient.GetResources("https://localhost:7046/api/ProgrammingLanguages/all");
                        WebDataViewer.PrintLanguages(languages);
                        Console.WriteLine("Please type resource id of language that you want to get: ");
                        id = int.Parse(Console.ReadLine());
                        language = await _webClient.GetResource("https://localhost:7046/api/ProgrammingLanguages", id);
                        WebDataViewer.PrintLanguage(language);
                        break;
                    case 4:
                        languages = await _webClient.GetResources("https://localhost:7046/api/ProgrammingLanguages/all");
                        WebDataViewer.PrintLanguages(languages);
                        Console.WriteLine("Please type resource id of language that you want to update: ");
                        id = int.Parse(Console.ReadLine());
                        language = await _webClient.GetResource("https://localhost:7046/api/ProgrammingLanguages", id);
                        language = UpdateProgrammingLanguage(language);
                        await _webClient.UpdateResource($"https://localhost:7046/api/ProgrammingLanguages/update/{id}", language);
                        languages = await _webClient.GetResources("https://localhost:7046/api/ProgrammingLanguages/all");
                        WebDataViewer.PrintLanguages(languages);
                        languages.ToList().Clear();
                        break;
                    case 5:
                        languages = await _webClient.GetResources("https://localhost:7046/api/ProgrammingLanguages/all");
                        WebDataViewer.PrintLanguages(languages);
                        Console.WriteLine("Please type resource id of language that you want to delete: ");
                        id = int.Parse(Console.ReadLine());
                        await _webClient.DeleteResource("https://localhost:7046/api/ProgrammingLanguages/delete", id);
                        languages = await _webClient.GetResources("https://localhost:7046/api/ProgrammingLanguages/all");
                        WebDataViewer.PrintLanguages(languages);
                        languages.ToList().Clear();
                        break;
                    default:
                        Console.WriteLine("Unknown option");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Please choose your next option: ");
                optionNumber = int.Parse(Console.ReadLine());
            }
        }

        private void ShowMenu()
        {
            var table = new ConsoleTable("Coomand Index", "Command", "Command Description");

            table.AddRow("1.", "Create", "Create a new resource")
                 .AddRow("2.", "GetAll", "Get all resources on the specified URL.")
                 .AddRow("3.", "GetById", "Get resource specified by id.")
                 .AddRow("4.", "Update", "Update resource specified by id.")
                 .AddRow("5.", "Delete", "Delete resource specified by id.")
                 .AddRow("6.", "Export in Excel", "Export the previous command result in Excel file.");

            table.Write();
            Console.WriteLine();
        }

        private ProgrammingLanguage CreateLocalResource()
        {
            Console.WriteLine("Please type language name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please type language description: ");
            string description = Console.ReadLine();

            return new ProgrammingLanguage()
            {
                Name = name,
                Description = description,
                Tutorials = new List<Tutorial>()
            };
        }


        private void ShowProgrammingLanguageInfo(ProgrammingLanguage programmingLanguage)
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Name =====> " + programmingLanguage.Name);
            Console.WriteLine("Description =====> " + programmingLanguage.Description);
            Console.WriteLine("=========================");
        }


        private ProgrammingLanguage UpdateProgrammingLanguage(ProgrammingLanguage programmingLanguage)
        {
            ShowProgrammingLanguageInfo(programmingLanguage);

            Console.WriteLine();
            Console.WriteLine("Which property do you want to change: ");
            string property = Console.ReadLine();

            switch (property)
            {
                case "Name":
                    Console.WriteLine("Type the new Name:");
                    programmingLanguage.Name = Console.ReadLine();
                    break;
                case "Description":
                    Console.WriteLine("Type the new Description:");
                    programmingLanguage.Description = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("There is no such property for the Programming Language!");
                    break;
            }

            programmingLanguage.Tutorials = new List<Tutorial>();

            return programmingLanguage;
        }
    }
}
