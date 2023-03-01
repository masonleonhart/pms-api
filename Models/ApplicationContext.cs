using Microsoft.EntityFrameworkCore;

namespace api.Models;

public class ApplicationContext : DbContext
{
  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
  public DbSet<User> Users { get; set; }
  public DbSet<UserJunction> UserJunctions { get; set; }
  public DbSet<Project> Projects { get; set; }
  public DbSet<Task> Tasks { get; set; }
}