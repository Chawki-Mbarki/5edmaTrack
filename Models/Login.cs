#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace khedmatrack.Models;

public class Login
{
  [Required]
  [EmailAddress(ErrorMessage = "Invalid email format.")]
  [MaxLength(50, ErrorMessage = "Email cannot be more than 50 characters.")]
  public string LoginEmail { get; set; }

  [Required]
  [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
  [DataType(DataType.Password)]
  public string LoginPassword { get; set; }

  [Required]
  public bool RememberMe { get; set; } = false;
}

