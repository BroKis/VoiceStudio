using System.ComponentModel.DataAnnotations;

namespace VoiceStudio.WebUI.Models.Outcoming;

public class StudioForDisplayWithActors
{
    public int Id { get; set; }

    [Display(Name = "Студия")]
    public string? Title { get; set; }
    
    [Display(Name = "Описание")]
    public string? Description { get; set; }
    
    [Display(Name = "Изображение")]
    public string? ImagePath { get; set; }
    [Display(Name = "Актеры данной студии")]
    public IEnumerable<ActorForDisplay> Actors { get; set; }
}