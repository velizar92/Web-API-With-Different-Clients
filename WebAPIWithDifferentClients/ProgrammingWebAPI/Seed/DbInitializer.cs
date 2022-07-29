namespace ProgrammingWebAPI.Seed
{
    using ProgrammingDataContext.Data;
    using ProgrammingModels.Models;

    public class DbInitializer : IDbInitializer
    {
        public async Task InitializeDatabase(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;

                await SeedProgrammingLanguages(serviceProvider);
            }
        }

        private async Task SeedProgrammingLanguages(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<ProgrammingDbContext>();

            List<ProgrammingLanguage> languages = new List<ProgrammingLanguage>
            {
                new ProgrammingLanguage
                {
                    Name = "C#",
                    Description = "C# is OOP language.",
                    Tutorials = new List<Tutorial>()
                    {
                        new Tutorial
                        {
                            Name = "1. C# Variables",
                            Description = "Intro to C# working with variables."
                        },
                        new Tutorial
                        {
                            Name = "2. C# Console Input/Output",
                            Description = "Working with Console Input/Output."
                        }
                    }
                },
                new ProgrammingLanguage
                {
                    Name = "Java",
                    Description = "Java is OOP language.",
                    Tutorials = new List<Tutorial>()
                    {
                        new Tutorial
                        {
                            Name = "1.Java variables",
                            Description = "Intro to Java working with variables."
                        },
                    }
                },
                new ProgrammingLanguage
                {
                    Name = "C++",
                    Description = "C++ is OOP language.",
                    Tutorials = new List<Tutorial>()
                    {
                        new Tutorial
                        {
                            Name = "1. C++ variables",
                            Description = "Intro to C++ working with variables."
                        },
                         new Tutorial
                        {
                            Name = "2. C++ Console Input/Output",
                            Description = "Intro to C++ working with variables."
                        },
                    }
                },
                new ProgrammingLanguage
                {
                    Name = "JavaScript",
                    Description = "JavaScript is programming language with first class functions.",
                    Tutorials = new List<Tutorial>()
                    {
                        new Tutorial
                        {
                            Name = "1. JavaScript Variables",
                            Description = "Intro to C# working with variables."
                        },
                    }
                },
            };

            if (!dbContext.ProgrammingLanguages.Any())
            {
                dbContext.ProgrammingLanguages.AddRange(languages);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
