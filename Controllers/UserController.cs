using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly ApplicationContext _c;
  public UserController(ApplicationContext c) { _c = c; }

  [HttpGet("{id}")]
  public IActionResult GetUser(int id)
  {
    User? user = _c.Users.Include(u => u.projects!).ThenInclude(p => p.tasks).ToList().SingleOrDefault(u => u.id == id);

    return user is null ? NotFound() : Ok(user);
  }

  [HttpPost]
  public IActionResult PostUser(User newUser)
  {
    DbSet<User> users = _c.Users;

    bool existingEmail = users.Any(u => u.email == newUser.email);

    if (existingEmail)
    {
      return BadRequest();
    }

    users.Add(newUser);
    _c.SaveChanges();

    return CreatedAtAction(nameof(GetUser), new { id = newUser.id }, newUser);
  }
}