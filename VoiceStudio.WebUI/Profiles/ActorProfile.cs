using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceStudio.WebUI.Models.Incoming;
using VoiceStudio.WebUI.Models.Outcoming;

namespace VoiceStudio.WebUI.Profiles;

public class ActorProfile:Profile
{
    public ActorProfile()
    {
        CreateMap<ActorForCreate,ActorDto>();
        CreateMap<ActorForUpdate, ActorDto>().ReverseMap();
        CreateMap<ActorDto, ActorForDisplay>();
    }
}