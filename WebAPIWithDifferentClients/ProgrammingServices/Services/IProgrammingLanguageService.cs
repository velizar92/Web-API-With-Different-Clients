namespace ProgrammingServices.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ProgrammingModels.Models;
    using ProgrammingServices.ServiceModels;
    
    public interface IProgrammingLanguageService
    {
        Task<IEnumerable<ProgrammingLanguageServiceModel>> GetAll();
        Task<ProgrammingLanguageServiceModel> GetById(int id);
        Task<ProgrammingLanguage> Create(ProgrammingLanguage programmingLanguage);
        Task Update(ProgrammingLanguage programmingLanguage);
        Task Delete(int id);
    }
}
