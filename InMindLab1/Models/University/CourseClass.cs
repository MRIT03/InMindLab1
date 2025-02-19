namespace InMindLab1.Models.University;

public class CourseClass
{
    public int CourseClassId { get; set; }
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
    public string DateTime { get; set; } 
    
    
    public virtual Course Course { get; set; }
    public virtual Teacher Teacher { get; set; }
    public virtual ICollection<Student> EnrolledStudents { get; set; }
}