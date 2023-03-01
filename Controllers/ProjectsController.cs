using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
  private readonly ApplicationContext _c;
  public ProjectController(ApplicationContext c) { _c = c; }

  [HttpGet("{id}")]
  public IActionResult GetProject(int id)
  {
    Project? project = _c.Projects.Include(p => p.tasks).ToList().SingleOrDefault(p => p.id == id);

    return project is null ? NotFound() : Ok(project);
  }

  [HttpPost]
  public IActionResult PostProject(Project newProject)
  {
    _c.Projects.Add(newProject);
    _c.SaveChanges();

    return CreatedAtAction(nameof(GetProject), new { id = newProject.id }, newProject);
  }
}