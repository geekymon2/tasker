using Microsoft.EntityFrameworkCore;

namespace GeekyMon2.Tasker.DB;

public class AppDBContext(DbContextOptions<AppDBContext> options, IConfiguration config, ILogger<AppDBContext> logger) : DbContext(options)
{
    private readonly IConfiguration _config = config;
    private readonly ILogger<AppDBContext> _logger = logger;
    public DbSet<Entities.Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _logger.LogInformation("Configuring DB Context");
 
        string endpoint = _config.GetValue<string>("AppConfig:CosmosEndpoint") ?? "";
        string key = _config.GetValue<string>("AppConfig:CosmosKey") ?? "";
        string db = _config.GetValue<string>("AppConfig:CosmosDatabase") ?? "";

        _logger.LogInformation("DB endpoint: {endpoint}", endpoint);
        _logger.LogInformation("DB Name: {db}", db);

        optionsBuilder.UseCosmos(
            accountEndpoint: endpoint,
            accountKey: key,
            databaseName: db
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        string container = _config.GetValue<string>("AppConfig:CosmosContainer") ?? "tasker-container-dev";

        _logger.LogInformation("Container Name: {container}", container);

        modelBuilder.Entity<Entities.Task>().Property(c => c.status).HasConversion<string>();
        modelBuilder.Entity<Entities.Task>().ToContainer(container).HasPartitionKey(x => x.Id);
    }
}