using AutoMapper;
using TeacherPortal.Models;

namespace TeacherPortal
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
