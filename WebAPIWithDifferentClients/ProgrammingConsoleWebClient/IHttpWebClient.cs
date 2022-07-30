namespace ProgrammingConsoleWebClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ProgrammingConsoleWebClient.ViewModels;

    public interface IHttpWebClient
    {
        Task<IEnumerable<ProgrammingLanguage>> GetResources(string resourceUrl);
        Task<ProgrammingLanguage> GetResource(string resourceUrl, int id);
        Task CreateResource(string resourceUrl, ProgrammingLanguage programmingLanguage);
        Task UpdateResource(string resourceUrl, ProgrammingLanguage programmingLanguage);
        Task DeleteResource(string resourceUrl, int id);
    }
}
