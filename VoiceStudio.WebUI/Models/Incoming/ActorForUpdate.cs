using System.ComponentModel.DataAnnotations;

namespace VoiceStudio.WebUI.Models.Incoming;

public class ActorForUpdate
{
  
    public int Id { get; set; }
    [Display(Name = "ФИО актера")]
    public string? FIO { get; set; }
    
    [Required(ErrorMessage = "Не указана дата рождения")]
    [Display(Name = "Дата рождения актера")]
  
    public DateTime? BirthDate { get; set; }
    
    [Required(ErrorMessage = "Не указана биография")]
    [Display(Name = "Биография актера")]
  
    public string? Biography { get; set; }
    
    [Required(ErrorMessage = "Не уазана ссылка на голос. Можно вставить ссылку с YouTube")]
    [Display(Name = "Голос актера")]
    
    public string? Voice { get; set; }
    
    [Required(ErrorMessage = "Не указана ссылка на фото актера")]
    [Display(Name = "Ccылка на фотографию актера")]
    
    public string? ImagePath { get; set; }
    
    [Required(ErrorMessage = "Не выбран статус актера")]
    [Display(Name = "Статус актера")]
    
    public int ActorStatusId { get; set; }
    [Required(ErrorMessage = "Не выбрана студия в которой работает актер")]
    [Display(Name = "Студия в которой работает актера")]
    public int StudioId { get; set; }
}