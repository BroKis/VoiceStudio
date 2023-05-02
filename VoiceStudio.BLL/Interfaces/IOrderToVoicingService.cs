using System.Linq.Expressions;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;

namespace Sound_VoiceStudio.BLL.Interfaces;

public interface IOrderToVoicingService
{
    public  BaseResponce<List<OrderToVoicingDTO>> GetFullApplications();


    public BaseResponce<bool> AddApplication(OrderToVoicingDTO application);


    public BaseResponce<bool> UpdateApplication(OrderToVoicingDTO newAppl);


    public BaseResponce<bool> DeleteApplication(int id);
    
    public BaseResponce<OrderToVoicingDTO> FindApplication(Expression<Func<OrderToVoicingDTO,bool>> criterion);

    public BaseResponce<OrderToVoicingDTO> FindByID(int id);

}