using AutoMapper;
using EMSAPI.DTO;
using EMSAPI.Model;

namespace EMSAPI.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ApplicationUser, SignupDTO>().ReverseMap()
            .ForMember(f => f.UserName, t2 => t2.MapFrom(src => src.Email));
        }
    }
}
