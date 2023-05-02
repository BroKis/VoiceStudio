using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Interfaces;
using VoiceStudio.WebUI.Models;
using VoiceStudio.WebUI.Models.Incoming;
using VoiceStudio.WebUI.Models.Outcoming;


namespace VoiceStudio.WebUI.Controllers;

public class ActorsController : Controller
{
    private IActorStatusService _actorStatusService;
    private IStudioService _studioService;
    private IActorService _actorService;
    private IMapper _mapper;
    private static List<StudioForDisplay> _studios = new List<StudioForDisplay>();
    private static List<ActorStatusForDisplay> _actorStatus = new List<ActorStatusForDisplay>();
    private static List<ActorForDisplay> _actors = new List<ActorForDisplay>();


    public ActorsController(IActorStatusService actorStatusService, IStudioService studioService,
        IActorService actorService, IMapper mapper)
    {
        _actorStatusService = actorStatusService;
        _studioService = studioService;
        _actorService = actorService;
        _mapper = mapper;
    }


    [HttpGet]
    public IActionResult DeleteActor(int id)
    {
        var resp = _actorService.DeleteActor(id);
        if (resp.Data)
        {
            return View("Success", "Home");
        }

        return View("NotFound", "Home");
    }

    [HttpGet]
    public IActionResult ActorDetail(int id)
    {
        if (_studios.Count == 0)
        {
            var studioData = _studioService.GetFullStudios();
            if (studioData.StatusCode == BLL.Enums.StatusCode.OK)
                _studios = _mapper.Map<List<StudioForDisplay>>(studioData.Data);
        }

        if (_actorStatus.Count == 0)
        {
            var actorStatusData = _actorStatusService.GetActorsStatuses();
            if (actorStatusData.StatusCode == BLL.Enums.StatusCode.OK)
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
            var actor = _actors.Find(x => x.Id == id);
            return View(actor);
        }
        catch (Exception e)
        {
            return View("NotFound", "Home");
        }
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        if (_studios.Count == 0)
        {
            var studioData = _studioService.GetFullStudios();
            if (studioData.StatusCode == BLL.Enums.StatusCode.OK)
                _studios = _mapper.Map<List<StudioForDisplay>>(studioData.Data);
        }

        if (_actorStatus.Count == 0)
        {
            var actorStatusData = _actorStatusService.GetActorsStatuses();
            if (actorStatusData.StatusCode == BLL.Enums.StatusCode.OK)
                _actorStatus = _mapper.Map<List<ActorStatusForDisplay>>(actorStatusData.Data);
        }
        ActorForUpdate actorForUpdate = new ActorForUpdate();
        try
        {
            var actorData = _actorService.GetByID(id);
            if (actorData.StatusCode == BLL.Enums.StatusCode.OK)
                actorForUpdate = _mapper.Map<ActorForUpdate>(actorData.Data);
            
            ViewBag.Studios = _studios.AsEnumerable();
            ViewBag.Statuses = _actorStatus.AsEnumerable();
            return View(actorForUpdate);
        }
        catch (Exception e)
        {
            return View("BadRequest", "Home");
        }
    }

    public IActionResult Create()
    {
        if (_studios.Count == 0)
        {
            var studioData = _studioService.GetFullStudios();
            if (studioData.StatusCode == BLL.Enums.StatusCode.OK)
                _studios = _mapper.Map<List<StudioForDisplay>>(studioData.Data);
        }

        if (_actorStatus.Count == 0)
        {
            var actorStatusData = _actorStatusService.GetActorsStatuses();
            if (actorStatusData.StatusCode == BLL.Enums.StatusCode.OK)
                _actorStatus = _mapper.Map<List<ActorStatusForDisplay>>(actorStatusData.Data);
        }

        ViewBag.Studios = _studios;
        ViewBag.Statuses = _actorStatus;
        return View();
    }

    [HttpPost]
    public IActionResult Create(ActorForCreate model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var data = _mapper.Map<ActorDto>(model);
        var resp = _actorService.AddActor(data);
        if (resp.StatusCode == BLL.Enums.StatusCode.OK)
            return View("Success", "Home");
        return View("BadRequest", "Home");
    }

    [HttpPost]
    public IActionResult Update(ActorForUpdate model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var data = _mapper.Map<ActorDto>(model);
        var resp = _actorService.UpdateActor(data);
        if (resp.StatusCode == BLL.Enums.StatusCode.OK)
            return View("Success", "Home");
        return View("BadRequest", "Home");
    }

    public IActionResult ActorsView()
    {
        try
        {
            if (_studios.Count == 0)
            {
                var studioData = _studioService.GetFullStudios();
                if (studioData.StatusCode == BLL.Enums.StatusCode.OK)
                    _studios = _mapper.Map<List<StudioForDisplay>>(studioData.Data);
            }

            if (_actorStatus.Count == 0)
            {
                var actorStatusData = _actorStatusService.GetActorsStatuses();
                if (actorStatusData.StatusCode == BLL.Enums.StatusCode.OK)
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

            return View(_actors);
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
}