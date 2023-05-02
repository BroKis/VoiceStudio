using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceSoundStudio.DAL.Models;

namespace Sound_VoiceStudio.BLL.Infrastructure.ProfilesForMapper;

public class TypesProfile:Profile
{
    public TypesProfile()
    {
        CreateMap<TypesDTO, Types>().
            ForMember(d => d.Id, opt =>
                opt.MapFrom(dd => dd.Id)).ReverseMap();
    }
}