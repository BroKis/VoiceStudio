using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;
using Sound_VoiceStudio.BLL.Interfaces;
using VoiceSoundStudio.DAL.Repository.Interfaces;
using VoiceStudio.BLL.Enums;

namespace Sound_VoiceStudio.BLL.Services;

public class ActorStatusService:IActorStatusService
{
    private IMapper _mapper;
    private IActorStatusRepository _actorStatusRepository;

    public ActorStatusService(IMapper mapper, IActorStatusRepository repo)
    {
        _mapper = mapper;
        _actorStatusRepository = repo;
    }
    public BaseResponce<List<ActorStatusDto>> GetActorsStatuses()
    { 
        try
        {
            var values = _mapper.Map<List<ActorStatusDto>>(_actorStatusRepository.GetAll());
            return new BaseResponce<List<ActorStatusDto>>()
            {
                Data = values,
                Description = "Data received successfully.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<List<ActorStatusDto>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }
    }
}