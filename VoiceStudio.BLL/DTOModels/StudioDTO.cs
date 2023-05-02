using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sound_VoiceStudio.BLL.DTOEntitys;

public class StudioDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    
    public string? ImagePath { get; set; }
    
   
}