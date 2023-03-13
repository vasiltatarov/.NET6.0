namespace SourceControl.Web.Areas.Admin.Controllers;

[Authorize(Roles = WebConstants.AdminRoleName)]
[Area(WebConstants.AdminAreaName)]
public class RepositoryImportExportPluginController : Controller
{
	private readonly IExcelImportExportService excelImportExportService;
	private readonly IRepositoryService repositoryService;

	public RepositoryImportExportPluginController(IExcelImportExportService excelImportExportService, IRepositoryService repositoryService)
	{
		this.excelImportExportService = excelImportExportService;
		this.repositoryService = repositoryService;
	}

	public IActionResult Index() => View();

	// Make async/await
	public ActionResult Export()
	{
		try
		{
			var file = this.excelImportExportService.ExportRepositories();

			return File(file.ReadStream, "application/octet-stream", file.Name);
		}
		catch (Exception ex)
		{
			var vm = new ImportExportErrorViewModel
			{
				Message = ex.Message,
				StackTrace = ex.StackTrace
			};

			return this.View("Error", vm);
		}
	}

	[HttpPost]
	public ActionResult Import(IFormFile file)
	{
		if (file == null || file.Length <= 0)
		{
			TempData["error"] = "File cannot be empty!";
			return this.View("Index");
		}

		try
		{
			this.repositoryService.ImportRepositories(file.OpenReadStream());
		}
		catch (Exception ex)
		{
			var vm = new ImportExportErrorViewModel
			{
				Message = ex.Message,
				StackTrace = ex.StackTrace
			};

			return this.View("Error", vm);
		}

		return this.View("Index");
	}
}
