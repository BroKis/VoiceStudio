using System.Linq.Expressions;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;

namespace Sound_VoiceStudio.BLL.Interfaces;

public interface IStudioService
{
    public BaseResponce<List<StudioDTO>> GetFullStudios();


    public BaseResponce<bool> AddStudio(StudioDTO newStudio);


    public BaseResponce<bool> DeleteStudio(int id);


    public BaseResponce<bool> UpdateStudio(StudioDTO updStudio);
    public BaseResponce<StudioDTO> FindByCriterion(Expression<Func<StudioDTO,bool>> criterion);

    public BaseResponce<StudioDTO> GetByID(int id);

}