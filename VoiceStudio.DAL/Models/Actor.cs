using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace VoiceSoundStudio.DAL.Models;


public class Actor
{
   
    public int Id { get; set; }
    public string? Fio { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Biography { get; set; }
    public string? Voice { get; set; }
    public string? ImagePath { get; set; }
    public int StudioId { get; set; }
 
    public virtual Studio Studio { get; set;}
    
   
    public int ActorStatusId { get; set; }
 
    public virtual ActorStatus ActorStatus { get; set;}
    
    public virtual List<OrderToVoicing> OrderVoicings { get; set; }
   public virtual ICollection<OrderToVoicingActor> OrderToVoicingActors { get; set; }




}