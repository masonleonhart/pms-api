using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
  private readonly ApplicationContext _c;
  public TaskController(ApplicationContext c) { _c = c; }

  [HttpGet("{id}")]
  public IActionResult GetTask(int id)
  {
    Task? task = _c.Tasks.Find(id);

    return task is null ? NotFound() : Ok(task);
  }

  [HttpPost]
  public IActionResult PostTask(Task newTask)
  {
    _c.Tasks.Add(newTask);
    _c.SaveChanges();

    return CreatedAtAction(nameof(GetTask), new { id = newTask.id }, newTask);
  }
}