using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Interfaces;
using VoiceStudio.WebUI.Models;
using VoiceStudio.WebUI.Models.Incoming;
using VoiceStudio.WebUI.Models.Outcoming;

namespace VoiceStudio.WebUI.Controllers;

public class StudioController : Controller
{
    private IActorStatusService _actorStatusService;
    private IStudioService _studioService;
    private IActorService _actorService;
    private IMapper _mapper;
    private static List<StudioForDisplay> _studios = new List<StudioForDisplay>();
    private static List<ActorStatusForDisplay> _actorStatus = new List<ActorStatusForDisplay>();
    private static List<ActorForDisplay> _actors = new List<ActorForDisplay>();




    public StudioController(IActorStatusService actorStatusService,IStudioService studioService,IActorService actorService,IMapper mapper)
    {
        _actorStatusService = actorStatusService;
        _studioService = studioService;
        _actorService = actorService;
        _mapper = mapper;
    }

    public IActionResult StudiosView()
    {
        if (_studios.Count == 0)
        {
            var studioData = _studioService.GetFullStudios();
            if(studioData.StatusCode == BLL.Enums.StatusCode.OK)
                _studios = _mapper.Map<List<StudioForDisplay>>(studioData.Data);
        }
        return View(_studios);
    }

    [HttpGet]
    public IActionResult StudioDetail(int id)
    {
        StudioForDisplayWithActors studioForDisplayWithActors = new StudioForDisplayWithActors();
        if (_actorStatus.Count == 0)
        {
            var actorStatusData = _actorStatusService.GetActorsStatuses();
            if(actorStatusData.StatusCode == BLL.Enums.StatusCode.OK)
                _actorStatus = _mapper.Map<List<ActorStatusForDisplay>>(actorStatusData.Data);
        }
        if (_actors.Count == 0)
        {
            var actorsData = _actorService.GetFullActors();
            if (actorsData.StatusCode == BLL.Enums.StatusCode.OK)
                _actors = _mapper.Map<List<ActorForDisplay>>(actorsData.Data);
            _actors.ForEach(x =>
            {
                x.Studio = _studios.Find(z => z.Id == x.StudioId).Title;
                x.Status = _actorStatus.Find(z => z.Id == x.ActorStatusId).Desc;
            });
        }
        try
        {

            studioForDisplayWithActors = _mapper.Map<StudioForDisplayWithActors>(_studios.Find(x => x.Id == id));
            studioForDisplayWithActors.Actors = _actors.Where(x => x.StudioId == studioForDisplayWithActors.Id);
            return View(studioForDisplayWithActors);
        }
        catch (Exception e)
        {
            View("Error",
                new ErrorViewModel
                {
                    Controller = "Home",
                    Description = e.Message
                });
        }

        return View("BadRequest", "Home"); 
        
    }

  

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var resp = _studioService.DeleteStudio(id);
        if (resp.Data)
        {
            return View("Success", "Home");
        }

        return View("NotFound", "Home");
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        StudioForUpdate studioForUpdate = new StudioForUpdate();
        try
        {
            var resp = _studioService.GetByID(id);
            if (resp.StatusCode == BLL.Enums.StatusCode.OK)
                studioForUpdate = _mapper.Map<StudioForUpdate>(resp.Data);
            return View(studioForUpdate);
        }
        catch (Exception e)
        {
           
            View("Error",
                new ErrorViewModel
                {
                    Controller = "Home",
                    Description = e.Message
                });
        }

        return View("BadRequest", "Home");
    }

    [HttpPost]
    public IActionResult Create(StudioForCreate model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var data = _mapper.Map<StudioDTO>(model);
        var resp = _studioService.AddStudio(data);
        if (resp.StatusCode == BLL.Enums.StatusCode.OK)
            return View("Success", "Home");
        return View("BadRequest", "Home");
    }

    [HttpPost]
    public IActionResult Update(StudioForUpdate model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var data = _mapper.Map<StudioDTO>(model);
        var resp = _studioService.UpdateStudio(data);
        if (resp.StatusCode == BLL.Enums.StatusCode.OK)
            return View("Success", "Home");
        return View("BadRequest", "Home");
        
    }
}