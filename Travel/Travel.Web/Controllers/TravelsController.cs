namespace Travel.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Travel.Services.Dtos;
    using Travel.Services.Interfaces;
    using Travel.Web.Models.Travels;

    [Authorize]
    public class TravelsController : Controller
    {
        private readonly ITravelService travelService;

        public TravelsController(ITravelService travelService)
            => this.travelService = travelService;

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
        public IActionResult Create(CreateTravelViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this.travelService.Create(new CreateTravelRequestModel
            {
                //TODO
            });

            return RedirectToAction("Index");
        }
    }
}
