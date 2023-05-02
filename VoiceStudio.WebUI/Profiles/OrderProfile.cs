using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceStudio.WebUI.Models.Incoming;
using VoiceStudio.WebUI.Models.Outcoming;

namespace VoiceStudio.WebUI.Profiles;

public class OrderProfile:Profile
{
    public OrderProfile()
    {
        CreateMap<OrderForCreate,OrderToVoicingDTO >();
        CreateMap<OrderForUpdate, OrderToVoicingDTO>().ReverseMap();
        CreateMap<OrderToVoicingDTO, OrderForDisplay>();
    }
}