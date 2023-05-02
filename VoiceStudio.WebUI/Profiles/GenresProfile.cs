using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceStudio.WebUI.Models.Outcoming;

namespace VoiceStudio.WebUI.Profiles;

public class GenresProfile:Profile
{
    public GenresProfile()
    {
        CreateMap<TypesDTO, GenresFilmForDisplay>();
    }
}