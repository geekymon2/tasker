namespace GeekyMon2.Tasker.Models;

public class TaskDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required TaskStatusDto status { get; set; }
}   