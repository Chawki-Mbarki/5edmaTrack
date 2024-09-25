#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace khedmatrack.Models;
public class Rating
{
  [Required]
  public int UserId { get; set; }

  [ForeignKey("UserId")]
  public User User { get; set; }

  [Required]
  public int MovieId { get; set; }

  [ForeignKey("MovieId")]
  public Movie Movie { get; set; }

  [Required]
  public bool Like { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
