using VoiceSoundStudio.DAL.Models;

namespace Sound_VoiceStudio.BLL.DTOEntitys;

public class OrderToVoicingDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Link { get; set; }
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }
    public int StudioId { get; set; }
    public int  TypeId { get; set; }
    public int StatusId { get; set; }
    
    public List<ActorDto> Actors { get; set; }
}