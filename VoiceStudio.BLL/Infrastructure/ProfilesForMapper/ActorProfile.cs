using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceSoundStudio.DAL.Models;

namespace Sound_VoiceStudio.BLL.Infrastructure.ProfilesForMapper;

public class ActorProfile:Profile
{
    public ActorProfile()
    {
        CreateMap<ActorDto, Actor>().
            ForMember(d => d.Id, opt =>
                opt.MapFrom(dd => dd.Id)).ReverseMap();
    }
    
}