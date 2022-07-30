namespace ProgrammingConsoleWebClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using ConsoleTables;
    using OfficeOpenXml;
    using ProgrammingConsoleWebClient.ViewModels;

    internal class Program
    {     
        static async Task Main(string[] args)
        {
            int id = 0;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ILogger consoleLogger = new ConsoleLogger();
            IHttpWebClient webClient = new HttpWebClient(consoleLogger);

            ShowMenu();

            Console.WriteLine("Please choose your option: ");
            int optionNumber = int.Parse(Console.ReadLine());

            while (true)
            {
                switch (optionNumber)
                {
                    case 1:
                        
                        break;
                    case 2:
                        var languages = await webClient.GetResources("https://localhost:7046/api/ProgrammingLanguages/all");                      
                        PrintLanguages(languages);
                        break;
                    case 3:
                        Console.WriteLine("Please type resource id: ");
                        id = int.Parse(Console.ReadLine());
                        var language = await webClient.GetResource("https://localhost:7046/api/ProgrammingLanguages/", id);
                        PrintLanguage(language);
                        break;
                    case 4:                      
                        break;
                    case 5:  
                        
                        break;
                    default:
                        Console.WriteLine("Unknown option");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Please choose your next option: ");
                optionNumber = int.Parse(Console.ReadLine());
            }

            //ProgrammingLanguage programmingLanguage = new ProgrammingLanguage()
            //{
            //    Name = "Python",
            //    Description = "Python is cool language.",
            //    Tutorials = new List<Tutorial>()
            //};

            //await webClient.CreateResource("https://localhost:7046/api/ProgrammingLanguages/create", programmingLanguage);

            //await webClient.DeleteResource("https://localhost:7046/api/ProgrammingLanguages/delete/2");

            //ProgrammingLanguage updatedPogrammingLanguage = new ProgrammingLanguage()
            //{
            //    Id = 5,
            //    Name = "Python",
            //    Description = "Python is cool language and will be updated soon.",
            //    Tutorials = new List<Tutorial>()
            //};

            //await webClient.UpdateResource("https://localhost:7046/api/ProgrammingLanguages/update/5", updatedPogrammingLanguage);

        }

        static void ShowMenu()
        {
            var table = new ConsoleTable("Coomand Index", "Command", "Command Description");

            table.AddRow("1.", "Create", "Create a new resource")
                 .AddRow("2.", "GetAll", "Get all resources on the specified URL.")
                 .AddRow("3.", "GetById","Get resource specified by id.")
                 .AddRow("4.", "Update", "Update resource specified by id.")
                 .AddRow("4.", "Delete", "Delete resource specified by id.")
                 .AddRow("5.", "Export in Excel", "Export the previous command result in Excel file.");

            table.Write();
            Console.WriteLine();
        }


        static void PrintLanguages(IEnumerable<ProgrammingLanguage> programmingLanguages)
        {
            var table = new ConsoleTable("Id", "Name", "Description");
        
            foreach (var programmingLanguage in programmingLanguages)
            {
                table.AddRow(programmingLanguage.Id, programmingLanguage.Name, programmingLanguage.Description);            
            }

            table.Write();
        }

        static void PrintLanguage(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage != null)
            {
                var table = new ConsoleTable("Id", "Name", "Description");
                table.AddRow(programmingLanguage.Id, programmingLanguage.Name, programmingLanguage.Description);
                table.Write();
            }    
        }

    }
}
