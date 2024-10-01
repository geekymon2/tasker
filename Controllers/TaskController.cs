using AutoMapper;
using GeekyMon2.Tasker.DB;
using GeekyMon2.Tasker.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekyMon2.Tasker.Controllers;

[ApiController]
public class TaskController(AppDBContext context, IMapper mapper) : ControllerBase
{
    private readonly AppDBContext _context = context;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [Route("/tasks")]
    public List<Models.TaskDto> GetTasks()
    {
        var tasks = _context.Tasks.ToList();
        var tasksDto = _mapper.Map<List<Models.TaskDto>>(tasks);
        return tasksDto;
    }

    [HttpPost]
    [Route("/task")]
    public string AddTasks(TaskDto taskDto)
    {
        Entities.Task task;
        task = _mapper.Map<Models.TaskDto, Entities.Task>(taskDto);
        string id = _context.Add<Entities.Task>(task).Entity.Id;
        _context.SaveChanges();

        return id;
    }

    [HttpDelete]
    [Route("/task/{id}")]
    public bool DeleteTask(string id)
    {
        //bool status = _context.<Entities.Task>(task).Entity.Id;
        bool status = true;
        _context.SaveChanges();

        return status;
    }
}