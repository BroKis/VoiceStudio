using System.Security.Policy;


namespace VoiceSoundStudio.DAL.Models;

public class Studio
{
   
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    
    public virtual List<Actor> Actors { get; set; } = new();
    public  virtual List<OrderToVoicing> FilmApplication { get; set; }


}