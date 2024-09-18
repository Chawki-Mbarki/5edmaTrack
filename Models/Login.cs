#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace Belt_Exam.Models;

public class Login
{
  [Required]
  [EmailAddress]
  public string LoginEmail { get; set; }

  [Required]
  [DataType(DataType.Password)]
  public string LoginPassword { get; set; }
}

