using System.ComponentModel.DataAnnotations;
using VoiceStudio.Identity.Models;

namespace VoiceStudio.WebUI.Models.IdentityModels;

public class UserForSignUp
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Display(Name = "ФИО/Название организации")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Номер телефона")]
    [StringLength(16,ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов", MinimumLength = 10)]
    public string PhoneNumber { get; set; } = string.Empty;

    

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    [StringLength(100, ErrorMessage =
        "Поле {0} должно иметь минимум {2} и максимум {1} символов", MinimumLength = 5)]
    
    public string Password { get; set; } = string.Empty;

    [Required] 
    [Display(Name = "Подтвердите пароль")]
    [Compare("Password", ErrorMessage = "Паролb не одинаковы")]
    [DataType(DataType.Password)]
   
    public string PasswordConfirm { get; set; } = string.Empty;

    [Required] 
    [Display(Name = "Роль")] 
    public string Role { get; set; } = AvailableRoles.Client;
}