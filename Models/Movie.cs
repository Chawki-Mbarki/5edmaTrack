#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace khedmatrack.Models;
public class Movie
{
  [Key]
  [Required]
  public int MovieId { get; set; }

  [ForeignKey("UserId")]
  public User? Creator { get; set; }
  public int? UserId { get; set; }

  [Required]
  [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
  public string Name { get; set; }

  [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
  public decimal? Rating { get; set; }

  [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
  public string? Description { get; set; }

  [StringLength(255, ErrorMessage = "Main actors' names cannot exceed 255 characters.")]
  public string? MainActors { get; set; }

  [Required]
  public DateTime? ReleaseDate { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
