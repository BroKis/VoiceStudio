using AutoMapper;
using VoiceStudio.Identity.Models;
using VoiceStudio.WebUI.Models.IdentityModels;

namespace VoiceStudio.WebUI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserForSignUp, ApplicationUser>().ForMember(dest => dest.UserName,
            opt => opt.MapFrom(src => src.Email));
    }
}