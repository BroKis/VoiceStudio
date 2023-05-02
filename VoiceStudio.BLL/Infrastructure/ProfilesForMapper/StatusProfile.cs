using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceSoundStudio.DAL.Models;

namespace Sound_VoiceStudio.BLL.Infrastructure.ProfilesForMapper;

public class StatusProfile:Profile
{
    public StatusProfile()
    {
        CreateMap<StatusDto, Status>().ForMember(s => s.Id,
            opt => opt.MapFrom(s => s.Id)).ReverseMap();
    }
}