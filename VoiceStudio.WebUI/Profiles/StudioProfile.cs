using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceStudio.WebUI.Models.Incoming;
using VoiceStudio.WebUI.Models.Outcoming;

namespace VoiceStudio.WebUI.Profiles;

public class StudioProfile:Profile
{
    public StudioProfile()
    {
        CreateMap<StudioDTO, StudioForDisplay>();
        CreateMap<StudioDTO, StudioForDisplayWithActors>();
        CreateMap<StudioForCreate, StudioDTO>();
        CreateMap<StudioForUpdate, StudioDTO>().ReverseMap();
        CreateMap<StudioForDisplay, StudioForDisplayWithActors>().ReverseMap();
    }
}