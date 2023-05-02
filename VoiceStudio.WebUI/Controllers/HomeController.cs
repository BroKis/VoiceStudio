using Microsoft.AspNetCore.Mvc;
using VoiceSoundStudio.DAL.Configuration.ConnectionConfiguration;

namespace VoiceStudio.WebUI.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Home()
    {
        return View();
    }

    
}