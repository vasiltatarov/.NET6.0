namespace SourceControl.Web.Controllers;

public class HomeController : Controller
{
	private readonly IRepositoryService repositoryService;

	public HomeController(IRepositoryService repositoryService)
	{
		this.repositoryService = repositoryService;
	}

	public async Task<IActionResult> Index()
    {
        var vm = new HomeViewModel
        {
            Repositories = await this.repositoryService.GetAll()
        };

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