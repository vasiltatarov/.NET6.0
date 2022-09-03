namespace Travel.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Security.Claims;
    using Travel.Web.Data;
    using Travel.Web.Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = this.User;
            if (user != null)
            {
                var id = user.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}