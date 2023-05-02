using Microsoft.AspNetCore.Mvc;
using VoiceStudio.BLL.Enums;

namespace Sound_VoiceStudio.BLL.Infrastructure.Respounce;

public class BaseResponce<T>
{
    public T Data { get; set; }
    public StatusCode StatusCode { get; set; }
    public string Description { get; set; }
}