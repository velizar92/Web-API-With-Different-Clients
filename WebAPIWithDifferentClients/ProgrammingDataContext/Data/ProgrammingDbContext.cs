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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
            modelBuilder.Entity<Tutorial>(e =>
                     e.HasOne(t => t.ProgrammingLanguage)
                    .WithMany(pl => pl.Tutorials)
                    .HasForeignKey(t => t.ProgrammingLanguageId)
                    .OnDelete(DeleteBehavior.Cascade));       
        }
    }
}
