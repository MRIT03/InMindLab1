using AutoMapper;
using InMindLab1.Models.University;
using InMindLab1.Models.University.ViewModels;

namespace InMindLab1.MappingProfiles;

public class UniversityProfile : Profile

{
    public UniversityProfile()
    {
        CreateMap<Student, StudentViewModel>();
        CreateMap<Course, CourseViewModel>();
        CreateMap<Teacher, TeacherViewModel>();
        CreateMap<CourseClass, CourseClassViewModel>()
            .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.Course.Title))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.Name));
        
    }
    
}