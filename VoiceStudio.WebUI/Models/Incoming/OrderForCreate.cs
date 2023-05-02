using System.ComponentModel.DataAnnotations;


namespace VoiceStudio.WebUI.Models.Incoming;

public class OrderForCreate
{
   
    [Required]
    [MinLength(10)]
    [Display(Name = "Название фильма")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "Не указана ссылка на скачивание")]
    [Display(Name = "Ссылка на скачивание")]
    [MinLength(10)]
    public string? Link { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    [Required(ErrorMessage = "Не выбрана текущая студия")]
    [Display(Name = "Студия записи")]
    public int StudioId{ get; set; }
    
    [Required(ErrorMessage = "Не выбран жанр фильма")]
    [Display(Name = "Жанр фильма")]
    public int TypeId { get; set; }
    
    public int UserID { get; set; }
    
    [Required(ErrorMessage = "Не выбран текущий статус")]
    [Display(Name = "Статус заказа")]
    public int StatusId { get; set; }
}