using System.Globalization;
using System.Net.Mime;
using InMindLab1.Models;
using InMindLab1.Services.StudentServices;
using Microsoft.AspNetCore.Mvc;

namespace InMindLab1.Controllers;

public class StudentController : Controller
{

    
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("[action]")]
    public List<Student> GetAllStudents()
    {
        return _studentService.GetAllStudents();
    }

    [HttpGet("[action]/{id}")]
    public Student GetStudentById([FromRoute] int id)
    {
        return _studentService.GetStudentById(id);
        
    }

    [HttpGet("[action]")]
    public List<Student> getStudentByName([FromQuery] string name)
    {
        return _studentService.getStudentByName(name);
    }

    [HttpGet("[action]")]
    public string date([FromHeader(Name = "Accepted-Language")] string language)
    {
        return _studentService.date(language);
    }

    [HttpPost("[action]")]
    public void changeName([FromBody] Student student)
    {
        _studentService.changeName(student);
    }

    
    [HttpPost("[action]")]
    public void UploadImage([FromForm] IFormFile file)
    {
        _studentService.UploadImage(file);
    }

    [HttpDelete("[action]/{id}")]
    public void deleteStudent([FromRoute] int id)
    {
        _studentService.deleteStudent(id);
    }
    
    
    
}