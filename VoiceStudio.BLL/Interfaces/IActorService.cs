using System.Linq.Expressions;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;

namespace Sound_VoiceStudio.BLL.Interfaces;

public interface IActorService
{
    public BaseResponce<List<ActorDto>> GetFullActors();


    public  BaseResponce<bool> AddActor(ActorDto newActor);


    public  BaseResponce<bool> DeleteActor(int id);


    public  BaseResponce<bool> UpdateActor(ActorDto updActor);

    public  BaseResponce<ActorDto> FindActor(Expression<Func<ActorDto,bool>> criterion);

    public BaseResponce<ActorDto> GetByID(int id);

}