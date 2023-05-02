using System.ComponentModel.DataAnnotations;

namespace VoiceStudio.WebUI.Models.Incoming;

public class StudioForCreate
{
    
    [Required]
    [Display(Name = "Название студии")]
    [StringLength(20,ErrorMessage = 
        "Поле {0} должно иметь минимум {2} и максимум {1} символов", MinimumLength = 5)]
    public string? Title { get; set; }
    
    
    [Required]
    [Display(Name = "Описание")]
    [MinLength(10)]
    public string? Description { get; set; }
    
    [Required]
    [Display(Name = "Ссылка на изображение")]
    [StringLength(100,ErrorMessage = 
        "Поле {0} должно иметь минимум {2} и максимум {1} символов", MinimumLength = 5)]
    public string? ImagePath { get; set; }
}