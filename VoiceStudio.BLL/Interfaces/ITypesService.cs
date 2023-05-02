using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Infrastructure.Respounce;

namespace Sound_VoiceStudio.BLL.Interfaces;

public interface ITypesService
{
    public  BaseResponce<List<TypesDTO>> GetFullTypes();
    public  BaseResponce<bool> InsertType(TypesDTO type);
    public  BaseResponce<bool> DeleteType(int id);
    public  BaseResponce<bool> UpdateType(TypesDTO type);

}