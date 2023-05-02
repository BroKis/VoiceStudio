using System.ComponentModel.DataAnnotations;

namespace VoiceStudio.WebUI.Models.IdentityModels;

public class UserForUpdate
{
    [Required]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Required]
    [Display(Name = "ФИО/Название организации")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Телефон")]
    public string Telephone { get; set; } = string.Empty;
    
  
   
}