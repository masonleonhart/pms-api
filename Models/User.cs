using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace api;

[Index(nameof(email), IsUnique = true)]
[Index(nameof(gAccessToken), IsUnique = true)]
public class User
{
  public int id { get; set; }

  [Required]
  public string? email { get; set; }

  [Required]
  public string? firstName { get; set; }

  [Required]
  public string? lastName { get; set; }

  [Required]
  public string? gAccessToken { get; set; }

  public ICollection<Project>? projects { get; set; }
}
