using System.ComponentModel.DataAnnotations;

namespace GeekyMon2.Tasker.Entities;

public class Task
{
    [Key]
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public bool IsComplete { get; set; }
}