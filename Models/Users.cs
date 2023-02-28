using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api
{
  public class User
  {
    public int id { get; set; }

    [Required]
    public string? name { get; set; }
  }
}