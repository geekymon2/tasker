using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GeekyMon2.Tasker.DB;

public class AppDBContext(DbContextOptions<AppDBContext> options, IConfiguration config) : DbContext(options)
{
    private readonly IConfiguration _config = config;
    public DbSet<Entities.Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string endpoint = _config.GetValue<string>("AppConfig:CosmosEndpoint") ?? "https://localhost:8081";
        string key = _config.GetValue<string>("AppConfig:CosmosKey") ?? "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        string db = _config.GetValue<string>("AppConfig:CosmosDatabase") ?? "tasker-db-dev";

        optionsBuilder.UseCosmos(
            accountEndpoint: endpoint,
            accountKey: key,
            databaseName: db
        );
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        string container = _config.GetValue<string>("AppConfig:CosmosContainer") ?? "tasker-container-dev";

        modelBuilder.Entity<Entities.Task>().Property(c => c.status).HasConversion<string>();
        modelBuilder.Entity<Entities.Task>().ToContainer(container).HasPartitionKey(x => x.Id);
    }
}