namespace ProgrammingDataContext.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ProgrammingModels.Models;

    public class ProgrammingDbContext : DbContext
    {
        public ProgrammingDbContext(DbContextOptions<ProgrammingDbContext> options)
            : base(options)
        {

        }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
    }
}
