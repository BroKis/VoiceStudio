

namespace VoiceSoundStudio.DAL.Models;

public class Types
{
    public int Id { get; set; }
    public string? Type { get; set; }
    
    public virtual OrderToVoicing Film { get; set; }
}