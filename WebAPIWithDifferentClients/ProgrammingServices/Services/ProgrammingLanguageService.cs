namespace ProgrammingServices.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ProgrammingDataContext.Data;
    using ProgrammingModels.Models;
    using ProgrammingServices.ServiceModels;

    public class ProgrammingLanguageService : IProgrammingLanguageService
    {
        private readonly ProgrammingDbContext _dbContext;

        public ProgrammingLanguageService(ProgrammingDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ProgrammingLanguage> Create(ProgrammingLanguage programmingLanguage)
        {
            await _dbContext.ProgrammingLanguages.AddAsync(programmingLanguage);

            await _dbContext.SaveChangesAsync();

            return programmingLanguage;
        }


        public async Task Delete(int id)
        {
            var programmingLanguage = _dbContext.ProgrammingLanguages.FindAsync(id);

            _dbContext.Remove(programmingLanguage);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<ProgrammingLanguageServiceModel>> GetAll()
        {
            return await _dbContext
                             .ProgrammingLanguages
                             .Select(pl => new ProgrammingLanguageServiceModel
                             {
                                 Id = pl.Id,
                                 Name = pl.Name,
                                 Description = pl.Description,
                                 Tutorials = pl.Tutorials
                             })
                             .ToListAsync();
        }

        public async Task<ProgrammingLanguageServiceModel> GetById(int id)
        {
            var programmingLanguage =
                await _dbContext
                        .ProgrammingLanguages
                        .Select(pl => new ProgrammingLanguageServiceModel
                        {
                            Id = pl.Id,
                            Name = pl.Name,
                            Description = pl.Description,
                            Tutorials = pl.Tutorials
                        })
                        .FirstOrDefaultAsync();

            return programmingLanguage;
        }


        public async Task Update(ProgrammingLanguage programmingLanguage)
        {
            _dbContext.Entry(programmingLanguage).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}
