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

public class StudioService:IStudioService
{
   
    private IStudioRepository _studioRepository;
    private IMapper _mapper;

    public StudioService(IStudioRepository repo, IMapper mapper)
    {
        
        _studioRepository = repo;
        _mapper = mapper;
    }
    
    public BaseResponce<List<StudioDTO>> GetFullStudios()
    {
        try
        {
            var values = _mapper.Map<List<StudioDTO>>( _studioRepository.GetAll());
            return new BaseResponce<List<StudioDTO>>()
            {
                Data = values,
                Description = "Data received successfully.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<List<StudioDTO>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }
    }

    public BaseResponce<bool> AddStudio(StudioDTO newStudio)
    {
        try
        {
            if (newStudio == null)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    StatusCode = StatusCode.NotFound,
                    Description = "Null object"
                };
            }
            
            Studio studio = _mapper.Map<Studio>(newStudio);
            _studioRepository.Insert(studio);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Studio successfully added.",
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

    public BaseResponce<bool> DeleteStudio(int id)
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

            _studioRepository.Delete(id);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Studio successfully deleted.",
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

    public BaseResponce<bool> UpdateStudio(StudioDTO updStudio)
    {
        try
        {
            if (updStudio == null)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    StatusCode = StatusCode.NotFound,
                    Description = "Null object"
                };
            }
            
            Studio studio = _mapper.Map<Studio>(updStudio);
            _studioRepository.Update(studio);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Studio successfully updated.",
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

    public BaseResponce<StudioDTO> FindByCriterion(Expression<Func<StudioDTO,bool>> criterion)
    {
       
        try
        {
            var replaced = FunctionReplacer.ReplaceParameter<Studio>(criterion); 
            var studio =  _studioRepository.Find(replaced);
            return new BaseResponce<StudioDTO>()
            {
                Data = _mapper.Map<StudioDTO>(studio),
                Description = "Studio successfully found.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<StudioDTO>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }

          
           
    }

    public BaseResponce<StudioDTO> GetByID(int id)
    {
        try
        {
            var studio = _studioRepository.GetID(id);
            return new BaseResponce<StudioDTO>()
            {
                Data = _mapper.Map<StudioDTO>(studio),
                Description = "Studio successfully found.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<StudioDTO>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }
    }
}