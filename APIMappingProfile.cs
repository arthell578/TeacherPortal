using AutoMapper;
using TeacherPortal.Models;

namespace TeacherPortal
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<CreateCourseDTO, Course>();
            CreateMap<Course, CourseDTO>();
            CreateMap<CreateLessonDTO, Lesson>();
            CreateMap<Lesson, LessonDTO>();
            CreateMap<UpdateLessonDTO, Lesson>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
