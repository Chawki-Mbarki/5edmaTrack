using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace khedmatrack.Models;

public class AccountUpdate
{
  public int? AccountId { get; set; }

  [MinLength(2, ErrorMessage = "First name must be at least 2 characters.")]
  [StringLength(25, ErrorMessage = "First name cannot be more than 25 characters.")]
  [Required]
  public string? AccountFirstName { get; set; }

  [MinLength(2, ErrorMessage = "Last name must be at least 2 characters.")]
  [StringLength(25, ErrorMessage = "Last name cannot be more than 25 characters.")]
  [Required]
  public string? AccountLastName { get; set; }

  [EmailAddress(ErrorMessage = "Invalid email format.")]
  [MaxLength(50, ErrorMessage = "Email cannot be more than 50 characters.")]
  [UniqueEmail]
  [Required]
  public string? AccountEmail { get; set; }

  [DataType(DataType.Password)]
  [PasswordCheck]
  public string? AccountPassword { get; set; }
}