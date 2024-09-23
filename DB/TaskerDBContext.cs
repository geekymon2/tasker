using Microsoft.EntityFrameworkCore;

namespace GeekyMon2.Tasker.DB
{
    public class TaskerDBContext : DbContext
    {

        public TaskerDBContext(DbContextOptions<TaskerDBContext> options) : base(options)
        {
        }

    }
}