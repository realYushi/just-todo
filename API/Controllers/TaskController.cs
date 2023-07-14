
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;

public class TasksController : BaseApiController
{
    private readonly DataContext _context;
    public TasksController(DataContext context)
    {
        _context = context;
    }
    [HttpGet] //api/tasks
    public async Task<ActionResult<List<Domain.Tasks>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }
    [HttpGet("{id}")] //api/task/id
    public async Task<ActionResult<Domain.Tasks>> GetTask(Guid id)
    {
        return await _context.Tasks.FindAsync(id);
    }

}
