namespace VoiceSoundStudio.DAL.Models;

public class ActorStatus
{
    public int Id { get; set; }
    public string? Desc { get; set; }
    
    public virtual Actor Actor { get; set; }
}