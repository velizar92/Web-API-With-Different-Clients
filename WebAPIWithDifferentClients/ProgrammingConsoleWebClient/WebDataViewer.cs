namespace ProgrammingConsoleWebClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ConsoleTables;
    using ProgrammingConsoleWebClient.ViewModels;

    public class WebDataViewer
    {
        public static void PrintLanguages(IEnumerable<ProgrammingLanguage> programmingLanguages)
        {
            var table = new ConsoleTable("Id", "Name", "Description");

            foreach (var programmingLanguage in programmingLanguages)
            {
                table.AddRow(programmingLanguage.Id, programmingLanguage.Name, programmingLanguage.Description);
            }

            table.Write();
        }

        public static void PrintLanguage(ProgrammingLanguage programmingLanguage)
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
