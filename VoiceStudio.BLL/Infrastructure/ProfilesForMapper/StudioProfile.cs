using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceSoundStudio.DAL.Models;

namespace Sound_VoiceStudio.BLL.Infrastructure.ProfilesForMapper;

internal class StudioProfile:Profile
{
    public StudioProfile()
    {
        CreateMap<StudioDTO, Studio>().
            ForMember(d => d.Id, opt =>
                opt.MapFrom(dd => dd.Id)).ReverseMap();
    }
    
}