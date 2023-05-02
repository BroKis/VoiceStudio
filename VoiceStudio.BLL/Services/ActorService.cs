using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;
using Sound_VoiceStudio.BLL.Infrastructure.Utils;
using Sound_VoiceStudio.BLL.Interfaces;
using VoiceSoundStudio.DAL.Models;
using VoiceSoundStudio.DAL.Repository.Interfaces;
using VoiceStudio.BLL.Enums;

namespace Sound_VoiceStudio.BLL.Services;

public class ActorService:IActorService
{
    private IMapper _mapper;
    private IActorRepository _actorRepository;


    public ActorService(IMapper mapper, IActorRepository actorRepository)
    {
        _mapper = mapper;
        _actorRepository = actorRepository;
       
    }
    
    public BaseResponce<List<ActorDto>> GetFullActors()
    {
        try
        {
            var values = _mapper.Map<List<ActorDto>>(_actorRepository.GetAll());
            return new BaseResponce<List<ActorDto>>()
            {
                Data = values,
                Description = "Data received successfully.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<List<ActorDto>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }
        
    }

    public BaseResponce<bool> AddActor(ActorDto newActor)
    {
        try
        {
            if (newActor == null)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    StatusCode = StatusCode.NotFound,
                    Description = "Null object"
                };
            }
            
            Actor actor = _mapper.Map<Actor>(newActor);
            _actorRepository.Insert(actor);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Actor successfully added",
                StatusCode = StatusCode.OK
            };
        }
        catch 
        {
            return new BaseResponce<bool>()
            {
                Data = false,
                Description = "Inevitable result",
                StatusCode = StatusCode.BadRequest
            };
        }
        
    }

    public BaseResponce<bool> DeleteActor(int id)
    {
        try
        {
            if (id <= 0)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    StatusCode = StatusCode.NotFound,
                    Description = "Object is null"
                };
            }

            _actorRepository.Delete(id);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Actor successfully deleted.",
                StatusCode = StatusCode.OK
            };
        }
        catch 
        {
            return new BaseResponce<bool>()
            {
                Data = false,
                Description = "Inevitable result",
                StatusCode = StatusCode.BadRequest
            };
        }
    }

    public BaseResponce<bool> UpdateActor(ActorDto updActor)
    {
        try
        {
            if (updActor == null)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    StatusCode = StatusCode.NotFound,
                    Description = "Null object"
                };
            }
            
            Actor actor = _mapper.Map<Actor>(updActor);
            _actorRepository.Update(actor);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Actor successfully updated.",
                StatusCode = StatusCode.OK
            };
        }
        catch 
        {
            return new BaseResponce<bool>()
            {
                Data = false,
                Description = "Inevitable result",
                StatusCode = StatusCode.BadRequest
            };
        }
    }

    public BaseResponce<ActorDto> FindActor(Expression<Func<ActorDto,bool>> criterion)
    {
        try
        {
            var replaced = FunctionReplacer.ReplaceParameter<Actor>(criterion); 
            var actor =  _actorRepository.Find(replaced);
            return new BaseResponce<ActorDto>()
            {
                Data = _mapper.Map<ActorDto>(actor),
                Description = "Actor successfully found.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<ActorDto>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }
    }

    public BaseResponce<ActorDto> GetByID(int id)
    {
        try
        {
            var actor = _actorRepository.GetID(id);
            return new BaseResponce<ActorDto>()
            {
                Data = _mapper.Map<ActorDto>(actor),
                Description = "Actor successfully found.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<ActorDto>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }
    }
}