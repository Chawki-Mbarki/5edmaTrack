using System.ComponentModel.DataAnnotations;
namespace khedmatrack.Models;

public class TransferViewModel
{
  [EmailAddress(ErrorMessage = "Invalid email format.")]
  [MaxLength(50, ErrorMessage = "Email cannot be more than 50 characters.")]
  [UniqueEmail]
  [Required]
  public string TransferEmail { get; set; }
}
