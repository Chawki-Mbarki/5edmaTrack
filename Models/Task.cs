#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace khedmatrack.Models;
public class Task
{
  [Key]
  [Required]
  public int TaskId { get; set; }

  [Required]
  public int UserId { get; set; }

  [ForeignKey("UserId")]
  public User User { get; set; }

  [Required]
  [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
  public string Title { get; set; }

  [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
  public string? Description { get; set; }

  [Required]
  [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
  public string Status { get; set; } = "Pending";

  [Required]
  public bool Important { get; set; } = false;

  public DateTime? DueDate { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
