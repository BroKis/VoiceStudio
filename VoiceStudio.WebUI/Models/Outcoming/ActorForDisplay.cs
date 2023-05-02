using System.ComponentModel.DataAnnotations;

namespace VoiceStudio.WebUI.Models.Outcoming;

public class ActorForDisplay
{
    public int Id { get; set; }
  
    [Display(Name = "ФИО актера")]
    public string? FIO { get; set; }
    [Required(ErrorMessage = "Не указана дата рождения")]
    [Display(Name = "Дата рождения актера")]
    public DateTime? BirthDate { get; set; }
    [Display(Name = "Биография актера")]
    public string? Biography { get; set; }
    
    [Display(Name = "Голос актера")]
    public string? Voice { get; set; }
    
    [Display(Name = "Фотография актера")]
    public string? ImagePath { get; set; }
    
   
    [Display(Name = "Статус актера")]
    
    public int ActorStatusId { get; set; }
    public string Status { get; set; }
    
    public int StudioId { get; set; }
    [Display(Name = "Студия актера")]
    public string Studio { get; set; }
}