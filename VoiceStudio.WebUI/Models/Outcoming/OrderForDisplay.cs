using System.ComponentModel.DataAnnotations;


namespace VoiceStudio.WebUI.Models.Outcoming;

public class OrderForDisplay
{
    public int Id { get; set; }
    
    [Display(Name = "Название фильма")]
    public string? Title { get; set; }
    
    [Display(Name = "Ссылка на скачивание")]
   
    public string? Link { get; set; }
    
    [Display(Name = "Дата заказа")]
    public DateTime OrderDate { get; set; }
    
    public int StudioId { get; set; }
    [Display(Name = "Студия испольнитель")]
    public string Studio { get; set; }
    
    public int TypeId { get; set; }
    [Display(Name = "Жанр фильма")]
    public string Genre { get; set; }
    
    public int UserID { get; set; }
    
    public int StatusId { get; set; }
    
    [Display(Name = "Статус заказа")]
    public string Status { get; set; }
    
  
    public List<ActorForDisplay> Actors { get; set; }
}