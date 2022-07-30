namespace ProgrammingConsoleWebClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ILogger consoleLogger = new ConsoleLogger();
            IHttpWebClient webClient = new HttpWebClient(consoleLogger);

            Engine engine = new Engine(webClient, consoleLogger);

            await engine.Run();
        }

    }
}
