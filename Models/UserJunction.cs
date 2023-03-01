using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api;

public class UserJunction
{
  public int id { get; set; }

  public User? firstUser { get; set; }

  [Required]
  public int firstUserId { get; set; }

  public User? secondUser { get; set; }

  [Required]
  public int secondUserId { get; set; }
}
