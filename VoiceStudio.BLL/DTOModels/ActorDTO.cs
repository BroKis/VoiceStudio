using VoiceSoundStudio.DAL.Models;

namespace Sound_VoiceStudio.BLL.DTOEntitys;

public class ActorDto
{
    
    public int Id { get; set; }
    public string? Fio { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Biography { get; set; }
    public string? Voice { get; set; }
    
    public string? ImagePath { get; set; }
    public int StudioId { get; set; }
    
    public int ActorStatusId { get; set; }
    
    
   
}