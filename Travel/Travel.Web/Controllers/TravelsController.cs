namespace Travel.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using Travel.Services.Dtos;
    using Travel.Services.Interfaces;
    using Travel.Web.Models.Travels;

    [Authorize]
    public class TravelsController : Controller
    {
        private readonly ITravelService travelService;
        private readonly IMapper mapper;

        public TravelsController(ITravelService travelService, IMapper mapper)
        {
            this.travelService = travelService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new TravelsViewModel
            {
                Travels = await this.travelService.GetTravelsAsync()
            };

            return View(vm);
        }

        public IActionResult Create()
            => View(new CreateTravelViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTravelViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var request = this.mapper.Map<CreateTravelRequestModel>(viewModel);
            request.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.travelService.Create(request);

            return RedirectToAction("Index");
        }
    }
}
