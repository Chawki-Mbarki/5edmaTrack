using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace khedmatrack.Models;
public class User
{
  [Key]
  [Required]
  public int UserId { get; set; }

  [Required]
  [MinLength(2, ErrorMessage = "First name must be at least 2 characters.")]
  [StringLength(25, ErrorMessage = "First name cannot be more than 25 characters.")]
  public required string FirstName { get; set; }

  [Required]
  [MinLength(2, ErrorMessage = "Last name must be at least 2 characters.")]
  [StringLength(25, ErrorMessage = "Last name cannot be more than 25 characters.")]
  public required string LastName { get; set; }

  [Required]
  [EmailAddress(ErrorMessage = "Invalid email format.")]
  [MaxLength(50, ErrorMessage = "Email cannot be more than 50 characters.")]
  [UniqueEmail]
  public required string Email { get; set; }

  [Required(ErrorMessage = "Password is required!")]
  [DataType(DataType.Password)]
  [PasswordCheck]
  public required string Password { get; set; }

  [NotMapped]
  [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
  public required string PasswordConfirm { get; set; }

  public List<Task> TasksCreated { get; set; } = new List<Task>();
  public List<Rating> Ratings { get; set; } = new List<Rating>();
  public List<Movie> MoviesCreated { get; set; } = new List<Movie>();

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}


public class UniqueEmailAttribute : ValidationAttribute
{
  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if (value == null)
      return new ValidationResult("Email is required!");

    var context = validationContext.GetService(typeof(MyContext)) as MyContext;
    var email = value.ToString();

    if (context != null && email != null)
    {
      var AccountIdProperty = validationContext.ObjectType.GetProperty("AccountId");
      var userInstance = validationContext.ObjectInstance;
      var AccountId = AccountIdProperty?.GetValue(userInstance) as int?;
      if (AccountId != null)
      {
        var existingUser = context.Users.FirstOrDefault(u => u.UserId == AccountId);
        if (existingUser != null && existingUser.Email == email)
          return ValidationResult.Success;
      }

      if (context.Users.Any(u => u.Email == email))
        return new ValidationResult("There is already an account with this Email.");
    }
    return ValidationResult.Success;
  }
}


public class PasswordCheckAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
  {
    var password = value as string;

    if (string.IsNullOrWhiteSpace(password))
      return ValidationResult.Success;

    if (password.Length < 8)
      return new ValidationResult("Password must be at least 8 characters long.");

    if (!Regex.IsMatch(password, @"\d"))
      return new ValidationResult("Password must contain at least one number.");

    if (!Regex.IsMatch(password, @"[a-zA-Z]"))
      return new ValidationResult("Password must contain at least one letter.");

    if (!Regex.IsMatch(password, @"[\W_]"))
      return new ValidationResult("Password must contain at least one special character.");

    return ValidationResult.Success!;
  }
}
