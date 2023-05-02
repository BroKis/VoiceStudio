using System.ComponentModel.DataAnnotations;

namespace VoiceStudio.WebUI.Models.Incoming;

public class ActorForCreate
{
  
    [Required(ErrorMessage = "Не указано ФИО")]
    [MinLength(5)]
    [Display(Name = "ФИО актера")]
    public string? FIO { get; set; }
    
    [Required(ErrorMessage = "Не указана дата рождения")]
    [Display(Name = "Дата рождения актера")]
    [DataType(DataType.DateTime)]
    public DateTime? BirthDate { get; set; }
    
    [Required(ErrorMessage = "Не указана биография")]
    [Display(Name = "Биография актера")]
    [MinLength(10)]
    public string? Biography { get; set; }
    
    [Required(ErrorMessage = "Не уазана ссылка на голос. Можно вставить ссылку с YouTube")]
    [Display(Name = "Голос актера")]
    [MinLength(10)]
    public string? Voice { get; set; }
    
    [Required(ErrorMessage = "Не указана ссылка на фото актера")]
    [Display(Name = "Ccылка на фотографию актера")]
    [MinLength(10)]
    public string? ImagePath { get; set; }
    
    [Required(ErrorMessage = "Не выбран статус актера")]
    [Display(Name = "Статус актера")]
    
    public int ActorStatusId { get; set; }
    [Required(ErrorMessage = "Не выбрана студия в которой работает актер")]
    [Display(Name = "Студия в которой работает актера")]
    public int StudioId { get; set; }
}