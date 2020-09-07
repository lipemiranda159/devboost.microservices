using devboost.dronedelivery.Infra.Data;

namespace devboost.dronedelivery.felipe.EF
{
    [ExcludeFromCodeCoverage]
    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<DataContext>();

            var connectionString = configuration.GetConnectionString("grupo4devboostdronedeliveryContext");

            dbContextBuilder.UseSqlServer(connectionString);

            return new DataContext(dbContextBuilder.Options);
        }
    }
}
