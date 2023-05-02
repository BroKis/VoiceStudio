namespace VoiceSoundStudio.DAL.Models;

public class OrderToVoicingActor
{
    public int ActorId { get; set; }
    
    public int OrderVoicingId { get; set; }
    
    public virtual Actor Actor { get; set; }
    public virtual OrderToVoicing OrderToVoicing { get; set; }
}