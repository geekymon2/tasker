using System.ComponentModel.DataAnnotations;

namespace GeekyMon2.Tasker.Entities;

public class Task
{
    [Key]
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public TaskStatus status { get; set; }
}