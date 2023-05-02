namespace VoiceSoundStudio.DAL.Models;

public class Status
{
    public int Id { get; set; }
    public string? Desc { get; set; }
    
    public virtual OrderToVoicing Film { get; set; }
    
}