using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace api;

public class Project
{
  public int id { get; set; }

  [Required]
  public string? title { get; set; }

  [JsonIgnore]
  public User? user { get; set; }

  [Required]
  public int userId { get; set; }

  public ICollection<Task>? tasks { get; set; }
}
