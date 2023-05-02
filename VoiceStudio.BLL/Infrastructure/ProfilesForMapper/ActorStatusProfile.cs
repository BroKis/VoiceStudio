using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceSoundStudio.DAL.Models;

namespace Sound_VoiceStudio.BLL.Infrastructure.ProfilesForMapper;

public class ActorStatusProfile:Profile
{
    public ActorStatusProfile()
    {
        CreateMap<ActorStatusDto, ActorStatus>()
            .ForMember(dd => dd.Id, opt =>
                opt.MapFrom(d => d.Id)).ReverseMap();
    }
}