using AutoMapper;
using GeekyMon2.Tasker.DB;
using Microsoft.AspNetCore.Mvc;

namespace GeekyMon2.Tasker.Controllers;

[ApiController]
public class TaskController : ControllerBase
{
    private readonly AppDBContext _context;
    private readonly IMapper _mapper;
    public TaskController(AppDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("/tasks")]
    public async List<Models.TaskDto> GetTasks()
    {
        var tasks = _context.Tasks.ToList();
        var tasksDto = _mapper.Map<List<Models.TaskDto>>(tasks);
        return tasksDto;
    }
}