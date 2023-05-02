using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;
using Sound_VoiceStudio.BLL.Interfaces;
using VoiceSoundStudio.DAL.Repository.Interfaces;
using VoiceSoundStudio.DAL.Repository.RepositoryRealisation;
using VoiceStudio.BLL.Enums;

namespace Sound_VoiceStudio.BLL.Services;

public class StatusService:IStatusService
{
    private IMapper _mapper;
    private IStatusRepository _repository;

    public StatusService(IMapper mapper, IStatusRepository repo)
    {
        _repository = repo;
        _mapper = mapper;
    }
    public BaseResponce<List<StatusDto>> GetStatuses()
    {
        try
        {
            var values = _mapper.Map<List<StatusDto>>(_repository.GetAll());
            return new BaseResponce<List<StatusDto>>()
            {
                Data = values,
                Description = "Data received successfully.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<List<StatusDto>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }
    }
}