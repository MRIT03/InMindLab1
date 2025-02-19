using InMindLab1.Models.University;
using Microsoft.EntityFrameworkCore;

namespace InMindLab1.Data;

public class UniversityContext : DbContext
{
    public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
    {
        
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<CourseClass> CourseClasses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseClass>()
            .HasMany(c => c.EnrolledStudents)
            .WithMany(s => s.EnrolledClasses)
            .UsingEntity(j => j.ToTable("CourseClassEnrollement"));
    }
}