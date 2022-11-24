namespace SourceControl.Web.Controllers;

[Authorize]
public class RepositoryController : Controller
{
    public IActionResult Index()
    {
        // Get all Repositories for current logged in user - public and private
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateRepositoryViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return RedirectToAction("Index");
    }
}
