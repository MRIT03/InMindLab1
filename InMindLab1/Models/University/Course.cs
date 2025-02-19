namespace InMindLab1.Models.University;

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    // Navigation properties
    public virtual ICollection<CourseClass>? Classes { get; set; }
}