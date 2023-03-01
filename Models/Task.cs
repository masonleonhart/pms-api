using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api;

public class Task
{
  public int id { get; set; }

  [Required]
  public string? title { get; set; }

  [JsonIgnore]
  public Project? project { get; set; }

  [Required]
  public int projectId { get; set; }
}
