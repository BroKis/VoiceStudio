using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sound_VoiceStudio.BLL.DTOEntitys;
using Sound_VoiceStudio.BLL.Interfaces;
using VoiceSoundStudio.DAL.Models;
using VoiceStudio.Identity.Models;
using VoiceStudio.WebUI.Models;
using VoiceStudio.WebUI.Models.Incoming;
using VoiceStudio.WebUI.Models.Outcoming;


namespace VoiceStudio.WebUI.Controllers;

public class OrderController : Controller
{
    private IActorStatusService _actorStatusService;
    private IStudioService _studioService;
    private IActorService _actorService;
    private IOrderToVoicingService _orderToVoicing;
    private ITypesService _typesService;
    private IStatusService _statusService;
    private IMapper _mapper;
    private static List<StudioForDisplay> _studios = new List<StudioForDisplay>();
    private static List<ActorStatusForDisplay> _actorStatus = new List<ActorStatusForDisplay>();
    private static List<ActorForDisplay> _actors = new List<ActorForDisplay>();
    private static List<OrderForDisplay> _orders = new List<OrderForDisplay>();
    private static List<GenresFilmForDisplay> _genres = new List<GenresFilmForDisplay>();
    private static List<StatusOrderForDisplay> _statusOrder = new List<StatusOrderForDisplay>();
    private UserManager<ApplicationUser> _userManager;

    public OrderController(IActorStatusService actorStatusService, IStudioService studioService,
        IActorService actorService,
        IOrderToVoicingService orderToVoicing, ITypesService typesService,
        IStatusService statusService, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _actorStatusService = actorStatusService;
        _studioService = studioService;
        _actorService = actorService;
        _orderToVoicing = orderToVoicing;
        _typesService = typesService;
        _statusService = statusService;
        _mapper = mapper;
        _userManager = userManager;
    }


    [HttpGet]
    public IActionResult Update(int id)
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

            if (_genres.Count == 0)
            {
                var genreData = _typesService.GetFullTypes();
                if (genreData.StatusCode == BLL.Enums.StatusCode.OK)
                    _genres = _mapper.Map<List<GenresFilmForDisplay>>(genreData.Data);
            }

            if (_statusOrder.Count == 0)
            {
                var statusData = _statusService.GetStatuses();
                if (statusData.StatusCode == BLL.Enums.StatusCode.OK)
                    _statusOrder = _mapper.Map<List<StatusOrderForDisplay>>(statusData.Data);
            }
        
            ViewBag.Studios = _studios;
            ViewBag.Type = _
        }
        catch (Exception e)
        {
            
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
        if (_genres.Count == 0)
        {
            var genreData = _typesService.GetFullTypes();
            if (genreData.StatusCode == BLL.Enums.StatusCode.OK)
                _genres = _mapper.Map<List<GenresFilmForDisplay>>(genreData.Data);
        }

        if (_statusOrder.Count == 0)
        {
            var statusData = _statusService.GetStatuses();
            if (statusData.StatusCode == BLL.Enums.StatusCode.OK)
                _statusOrder = _mapper.Map<List<StatusOrderForDisplay>>(statusData.Data);
        }

        ViewBag.Studios = _studios;
        ViewBag.Genres = _genres;
        
        return View();
    }

    [HttpPost]
    public IActionResult Create(OrderForCreate model)
    {
        if (_statusOrder.Count == 0)
        {
            var statusData = _statusService.GetStatuses();
            if (statusData.StatusCode == BLL.Enums.StatusCode.OK)
                _statusOrder = _mapper.Map<List<StatusOrderForDisplay>>(statusData.Data);
        }
        model.OrderDate = DateTime.Today;
        model.UserID = Convert.ToInt32(_userManager.GetUserId(User));
        model.StatusId = _statusOrder[0].Id;
        if (!ModelState.IsValid)
        {
            ViewBag.Studios = _studios;
            ViewBag.Genres = _genres;
            return View(model);
        }

        var data = _mapper.Map<OrderToVoicingDTO>(model);
        var resp = _orderToVoicing.AddApplication(data);
        if (resp.StatusCode == BLL.Enums.StatusCode.OK)
            return View("Success", "Home");
        return View("BadRequest", "Home");


    }

    public IActionResult OrdersForClient()
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

            if (_genres.Count == 0)
            {
                var genreData = _typesService.GetFullTypes();
                if (genreData.StatusCode == BLL.Enums.StatusCode.OK)
                    _genres = _mapper.Map<List<GenresFilmForDisplay>>(genreData.Data);
            }

            if (_statusOrder.Count == 0)
            {
                var statusData = _statusService.GetStatuses();
                if (statusData.StatusCode == BLL.Enums.StatusCode.OK)
                    _statusOrder = _mapper.Map<List<StatusOrderForDisplay>>(statusData.Data);
            }

            if (_orders.Count == 0)
            {
                var orderData = _orderToVoicing.GetFullApplications();
                if (orderData.StatusCode == BLL.Enums.StatusCode.OK)
                    _orders = _mapper.Map<List<OrderForDisplay>>(orderData.Data);
                _orders.ForEach(x =>
                {
                    x.Studio = _studios.Find(z => z.Id == x.StudioId).Title;
                    x.Genre = _genres.Find(z => z.Id == x.TypeId).Type;
                    x.Status = _statusOrder.Find(z => z.Id == x.StatusId).Desc;
                });
            }
            var userOrders = _orders.Where(x => x.UserID == Convert.ToInt16(_userManager.GetUserId(User)));
            return View(userOrders);
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

     public IActionResult OrdersForStudio()
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

            if (_genres.Count == 0)
            {
                var genreData = _typesService.GetFullTypes();
                if (genreData.StatusCode == BLL.Enums.StatusCode.OK)
                    _genres = _mapper.Map<List<GenresFilmForDisplay>>(genreData.Data);
            }

            if (_statusOrder.Count == 0)
            {
                var statusData = _statusService.GetStatuses();
                if (statusData.StatusCode == BLL.Enums.StatusCode.OK)
                    _statusOrder = _mapper.Map<List<StatusOrderForDisplay>>(statusData.Data);
            }

            if (_orders.Count == 0)
            {
                var orderData = _orderToVoicing.GetFullApplications();
                if (orderData.StatusCode == BLL.Enums.StatusCode.OK)
                    _orders = _mapper.Map<List<OrderForDisplay>>(orderData.Data);
                _orders.ForEach(x =>
                {
                    x.Studio = _studios.Find(z => z.Id == x.StudioId).Title;
                    x.Genre = _genres.Find(z => z.Id == x.TypeId).Type;
                    x.Status = _statusOrder.Find(z => z.Id == x.StatusId).Desc;
                });
            }
           
            return View(_orders);
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
    // [HttpPost]
    // public IActionResult InputOrder(OrderViewModel model)
    // {
    //     if (_studioModels.Count == 0)
    //         _studioModels = _studioModelService.StudioFill().Data;
    //     if (_statusModels.Count == 0)
    //         _statusModels = _statusModelService.FullStatuses().Data;
    //     if (_typesModels.Count == 0)
    //         _typesModels = _typesModelsService.TypesFull().Data;
    //
    //     model.Order.StudioModel = _studioModels.FirstOrDefault(x => x.ID == model.Order.StudioModel.ID);
    //     model.Order.TypeModel = _typesModels.FirstOrDefault(x => x.ID == model.Order.TypeModel.ID);
    //     model.Order.StatusModel = _statusModels.FirstOrDefault();
    //     model.Order.OrderDate = DateTime.Today;
    //
    //     var AddResp = _orderModelService.AddNewOrder(model.Order);
    //     if (AddResp.Data)
    //         return View("Success", "Home");
    //     else
    //         return View("BadRequest", "Home");
    // }

    [HttpGet]
    public IActionResult ViewActors(int id)
    {
        var actors = _orders.Find(x => x.Id == id).Actors;
        return View("ActorsView", actors);
    }
}