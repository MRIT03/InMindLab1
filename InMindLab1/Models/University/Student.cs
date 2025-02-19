namespace InMindLab1.Models.University;

public class Student : Person
{
    public long Id { get; set; }
    public string Name {get; set;}
    public string Email {get; set;}

    public Student(long id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public virtual ICollection<CourseClass>? EnrolledClasses { get; set; }
}