using Microsoft.EntityFrameworkCore;

namespace GeekyMon2.Tasker.DB;

public class AppDBContext : DbContext
{
    public DbSet<Entities.Task> Tasks { get; set; }

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            "https://localhost:8081",
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
            "tasker"
        );
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Task>().ToContainer("tasks").HasKey(x => x.Id);
    }
}