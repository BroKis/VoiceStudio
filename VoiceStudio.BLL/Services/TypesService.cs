using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;
using Sound_VoiceStudio.BLL.Interfaces;
using VoiceSoundStudio.DAL.Models;
using VoiceSoundStudio.DAL.Repository.Interfaces;
using VoiceStudio.BLL.Enums;

namespace Sound_VoiceStudio.BLL.Services;

public class TypesService:ITypesService
{
    private ITypesRepository _typesRepository;
    private IMapper _mapper;

    public TypesService(ITypesRepository repo, IMapper mapper)
    {
        _typesRepository = repo;
        _mapper = mapper;
    }
    public BaseResponce<List<TypesDTO>> GetFullTypes()
    {
        try
        {
            var values = _mapper.Map<List<TypesDTO>>(_typesRepository.GetAll());
            return new BaseResponce<List<TypesDTO>>()
            {
                Data = values,
                Description = "Data received successfully.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<List<TypesDTO>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }
    }

    public BaseResponce<bool> InsertType(TypesDTO type)
    {
        try
        {
            if (type == null)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    StatusCode = StatusCode.NotFound,
                    Description = "Null object"
                };
            }
            
            Types typeinp = _mapper.Map<Types>(type);
            _typesRepository.Insert(typeinp);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Ok result.",
                StatusCode =StatusCode.OK
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

    public BaseResponce<bool> DeleteType(int id)
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

            _typesRepository.Delete(id);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Ok result.",
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

    public BaseResponce<bool> UpdateType(TypesDTO type)
    {
        try
        {
            if (type == null)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    StatusCode = StatusCode.NotFound,
                    Description = "Null object"
                };
            }
            
            Types typesupd = _mapper.Map<Types>(type);
            _typesRepository.Update(typesupd);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Ok result.",
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
    
}