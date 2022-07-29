namespace ProgrammingWebAPI.Seed
{
    public interface IDbInitializer
    {
        Task InitializeDatabase(IApplicationBuilder applicationBuilder);
    }
}
