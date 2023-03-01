using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserJunctionsController : ControllerBase
{
  private readonly ApplicationContext _c;
  public UserJunctionsController(ApplicationContext c) { _c = c; }

  [HttpGet("{id}")]
  public IActionResult GetUserJunction(int id)
  {
    UserJunction? userJunction = _c.UserJunctions.Include(u => u.firstUser!)
      .ThenInclude(u => u.projects!).ThenInclude(p => p.tasks)
    .Include(u => u.secondUser!)
      .ThenInclude(u => u.projects!).ThenInclude(p => p.tasks)
    .AsSplitQuery().ToList().SingleOrDefault(u => u.id == id);

    return userJunction is null ? NotFound() : Ok(userJunction);
  }

  [HttpPost]
  public IActionResult PostUser(UserJunction newUserJunction)
  {
    DbSet<User> users = _c.Users;

    User? firstUser = users.Find(newUserJunction.firstUserId);
    User? secondUser = users.Find(newUserJunction.secondUserId);

    if (firstUser is null || secondUser is null)
    {
      return NotFound();
    }

    _c.UserJunctions.Add(newUserJunction);
    _c.SaveChanges();

    return CreatedAtAction(nameof(GetUserJunction), new { id = newUserJunction.id }, newUserJunction);
  }
}