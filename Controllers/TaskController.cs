using GeekyMon2.Tasker.DB;
using Microsoft.AspNetCore.Mvc;

namespace GeekyMon2.Tasker.Controllers;

[ApiController]
public class TaskController : ControllerBase
{
    private readonly AppDBContext _context;
    public TaskController(AppDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("/tasks")]
    public string GetTasks()
    {
        return "This will return all tasks";
    }
}