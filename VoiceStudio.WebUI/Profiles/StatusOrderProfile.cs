using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceStudio.WebUI.Models.Outcoming;

namespace VoiceStudio.WebUI.Profiles;

public class StatusOrderProfile:Profile
{
    public StatusOrderProfile()
    {
        CreateMap<StatusDto, StatusOrderForDisplay>();
    }
}