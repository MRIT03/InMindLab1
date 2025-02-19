namespace InMindLab1.Models.University;

public class Teacher
{
    public int TeacherId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    
    public virtual ICollection<CourseClass>? Classes { get; set; }
}