using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;

namespace Sound_VoiceStudio.BLL.Interfaces;

public interface IStatusService
{
    public  BaseResponce<List<StatusDto>> GetStatuses();
}