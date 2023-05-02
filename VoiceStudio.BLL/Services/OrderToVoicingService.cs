using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;
using Sound_VoiceStudio.BLL.Infrastructure.Utils;
using Sound_VoiceStudio.BLL.Interfaces;
using VoiceSoundStudio.DAL.Models;
using VoiceSoundStudio.DAL.Repository.Interfaces;
using VoiceStudio.BLL.Enums;

namespace Sound_VoiceStudio.BLL.Services;

public class OrderToVoicingService:IOrderToVoicingService
{
    private IOrderToVoicicngRepository _filmRepository;
    private IMapper _mapper;

    public OrderToVoicingService(IOrderToVoicicngRepository repo, IMapper mapper)
    {
        _filmRepository = repo;
        _mapper = mapper;
    }
    public BaseResponce<List<OrderToVoicingDTO>> GetFullApplications()
    {
        try
        {
            var values = _mapper.Map<List<OrderToVoicingDTO>>(_filmRepository.GetAll());
            return new BaseResponce<List<OrderToVoicingDTO>>()
            {
                Data = values,
                Description = "Data received successfully.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<List<OrderToVoicingDTO>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }
    }

    public BaseResponce<bool> AddApplication(OrderToVoicingDTO application)
    {
        try
        {
            if (application == null)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    StatusCode = StatusCode.NotFound,
                    Description = "Null object"
                };
            }
            
            OrderToVoicing film = _mapper.Map<OrderToVoicing>(application);
            _filmRepository.Insert(film);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Order successfully added.",
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

    public BaseResponce<bool> UpdateApplication(OrderToVoicingDTO application)
    {
        try
        {
            if (application == null)
            {
                return new BaseResponce<bool>()
                {
                    Data = false,
                    StatusCode = StatusCode.NotFound,
                    Description = "Null object"
                };
            }
            
            OrderToVoicing film = _mapper.Map<OrderToVoicing>(application);
            _filmRepository.Update(film);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Order successfully updated.",
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

    public BaseResponce<bool> DeleteApplication(int id)
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

            _filmRepository.Delete(id);
            return new BaseResponce<bool>()
            {
                Data = true,
                Description = "Order successfully deleted.",
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

    public BaseResponce<OrderToVoicingDTO> FindApplication(Expression<Func<OrderToVoicingDTO,bool>> criterion)
    {
        try
        {
            var replaced = FunctionReplacer.ReplaceParameter<OrderToVoicing>(criterion); 
            var film =  _filmRepository.Find(replaced);
            return new BaseResponce<OrderToVoicingDTO>()
            {
                Data = _mapper.Map<OrderToVoicingDTO>(film),
                Description = "Order successfully found.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<OrderToVoicingDTO>()
            {
                Description = ex.Message,
                StatusCode =StatusCode.BadRequest
            };
        }
    }

    public BaseResponce<OrderToVoicingDTO> FindByID(int id)
    {
        try
        {

            var film = _filmRepository.GetID(id);
            return new BaseResponce<OrderToVoicingDTO>()
            {
                Data = _mapper.Map<OrderToVoicingDTO>(film),
                Description = "Order successfully found.",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponce<OrderToVoicingDTO>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.BadRequest
            };
        }
    }
}