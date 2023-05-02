using System.ComponentModel.DataAnnotations;

namespace VoiceStudio.WebUI.Models.Incoming;

public class OrderForUpdate
{
    [Required]
    [Display(Name = "Название фильма")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "Не указана ссылка на скачивание")]
    [Display(Name = "Ссылка на скачивание")]
    public string? Link { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    
    [Display(Name = "Студия записи")]
    public string Studio { get; set; }
    public int StudioId{ get; set; }
    
    
    [Display(Name = "Жанр фильма")]
    public string Genre { get; set; }
    public int TypeId { get; set; }
    
    public int UserID { get; set; }
    
    [Required(ErrorMessage = "Не выбран текущий статус")]
    [Display(Name = "Статус заказа")]
    public int StatusId { get; set; }
    
    [Required(ErrorMessage = "Не выбраны актеры")]
    [Display(Name = "Актеры озвучки")]
    public List<int> ActorsId { get; set; }
}