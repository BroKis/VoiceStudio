using Microsoft.AspNetCore.Mvc;
using VoiceStudio.BLL.Enums;

namespace VoiceStudio.Identity.Utils;

public class Response<T>
{
    public T Data { get; set; }

    public StatusCode StatusCode { get; set; }

    public string Description { get; set; } = string.Empty;
}