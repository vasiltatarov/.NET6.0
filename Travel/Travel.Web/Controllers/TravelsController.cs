namespace Travel.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Travel.Services.Interfaces;
    using Travel.Web.Models.Travels;

    [Authorize]
    public class TravelsController : Controller
    {
        private readonly ITravelService travelService;

        public TravelsController(ITravelService travelService)
            => this.travelService = travelService;

        public async Task<IActionResult> AllTravels()
        {
            var vm = new TravelsViewModel();
            vm.Travels = await this.travelService.GetTravelsAsync();

            return View(vm);
        }
    }
}
