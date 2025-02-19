// Controllers/UniversityController.cs
using AutoMapper;
using InMindLab1.Data;
using InMindLab1.Models.University;
using InMindLab1.Models.University.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UniversityController : ControllerBase
{
    private readonly UniversityContext _context;
    private readonly IMapper _mapper;

    public UniversityController(UniversityContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

   
    [HttpPost("students")]
    public async Task<IActionResult> AddStudent([FromBody] Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<StudentViewModel>(student));
    }

    
    [HttpPost("teachers")]
    public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<TeacherViewModel>(teacher));
    }

    
    [HttpPost("courses")]
    public async Task<IActionResult> AddCourse([FromBody] Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<CourseViewModel>(course));
    }

    
    [HttpPost("classes")]
    public async Task<IActionResult> AddClass([FromBody] CourseClass courseClass)
    {
       
        _context.CourseClasses.Add(courseClass);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<CourseClassViewModel>(courseClass));
    }

    
    [HttpPost("classes/{classId}/enroll")]
    public async Task<IActionResult> EnrollStudent(int classId, [FromQuery] int studentId)
    {
        var courseClass = await _context.CourseClasses
            .Include(cc => cc.EnrolledStudents)
            .FirstOrDefaultAsync(cc => cc.CourseClassId == classId);
        if (courseClass == null)
        {
            return NotFound("Class not found.");
        }
        var student = await _context.Students.FindAsync(studentId);
        if (student == null)
        {
            return NotFound("Student not found.");
        }
        courseClass.EnrolledStudents.Add(student);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<CourseClassViewModel>(courseClass));
    }

    
    [HttpDelete("classes/{classId}")]
    public async Task<IActionResult> RemoveClass(int classId)
    {
        var courseClass = await _context.CourseClasses.FindAsync(classId);
        if (courseClass == null)
        {
            return NotFound("Class not found.");
        }
        _context.CourseClasses.Remove(courseClass);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
