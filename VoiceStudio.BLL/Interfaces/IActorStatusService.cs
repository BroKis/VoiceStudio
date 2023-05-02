using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;

namespace Sound_VoiceStudio.BLL.Interfaces;

public interface IActorStatusService
{
    public BaseResponce<List<ActorStatusDto>> GetActorsStatuses();
}