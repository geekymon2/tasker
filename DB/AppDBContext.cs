using Microsoft.EntityFrameworkCore;

namespace GeekyMon2.Tasker.DB;

public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
{
    public DbSet<Entities.Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            "https://localhost:8081",
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
            "tasker-db"
        );
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Task>().ToContainer("tasker-container").HasPartitionKey(x => x.Id);
    }
}