using System.Security.Claims;

namespace SourceControl.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly IMapper mapper;

    public HomeController(ILogger<HomeController> logger, IMapper mapper)
    {
        this.logger = logger;
        this.mapper = mapper;
    }

    public IActionResult Index()
    {
        var homeDto = new HomeDto
        {
            Username = User.FindFirstValue(ClaimTypes.Name),
            UserId = User.UserId(),
            Age = 25,
        };

        var vm = this.mapper.Map<HomeViewModel>(homeDto);

        return View(vm);
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