using System.ComponentModel.DataAnnotations;

namespace VoiceStudio.WebUI.Models.Incoming;

public class StudioForUpdate
{
    
    public int Id { get; set; }
    [Display(Name = "Название студии")]
    public string? Title { get; set; }
    
    [Display(Name = "Описание")]
    public string? Description { get; set; }
    
  
    [Display(Name = "Ссылка на изображение")]
    public string? ImagePath { get; set; }
}