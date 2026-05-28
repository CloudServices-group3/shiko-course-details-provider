using CourseDetailsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseDetailsApi.Data;

public class CourseDetailsDbContext : DbContext
{
    public CourseDetailsDbContext(DbContextOptions<CourseDetailsDbContext> options) : base(options) { }

    public DbSet<CourseDetail> CourseDetails { get; set; }
    public DbSet<KeyPoint> KeyPoints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("coursedetails");

        modelBuilder.Entity<CourseDetail>()
            .HasMany(c => c.KeyPoints)
            .WithOne()
            .HasForeignKey(kp => kp.CourseId);
    }
}