

namespace VoiceSoundStudio.DAL.Models;

public class OrderToVoicing
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Link { get; set; }
    public DateTime OrderDate { get; set; }
    public int StudioId { get; set; }
    public virtual Studio? Studio { get; set; }

    public int TypeId { get; set; }
    
    public virtual Types Type { get; set; }
    
    public int UserId { get; set; }
    
    public int StatusId { get; set; }
    
    public virtual Status Status { get; set; }
    
    public virtual List<Actor> Actors { get; set; }
    public virtual ICollection<OrderToVoicingActor> OrderToVoicingActors { get; set; }




}