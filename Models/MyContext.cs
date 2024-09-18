#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;

namespace khedmatrack.Models;
public class MyContext : DbContext
{
  public MyContext(DbContextOptions options) : base(options) { }

  public DbSet<User> Users { get; set; }
  public DbSet<Task> Tasks { get; set; }
  public DbSet<Movie> Movies { get; set; }
  public DbSet<Rating> Ratings { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Rating>()
      .HasKey(r => new { r.UserId, r.MovieId });
  }
}
