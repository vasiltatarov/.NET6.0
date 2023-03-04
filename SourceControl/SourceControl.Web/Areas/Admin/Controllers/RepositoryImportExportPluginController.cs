namespace SourceControl.Web.Areas.Admin.Controllers;

[Authorize(Roles = WebConstants.AdminRoleName)]
[Area(WebConstants.AdminAreaName)]
public class RepositoryImportExportPluginController : Controller
{
    private readonly IExcelImportExportService excelImportExportService;

    public RepositoryImportExportPluginController(IExcelImportExportService excelImportExportService)
    {
        this.excelImportExportService = excelImportExportService;
    }

    public IActionResult Index() => View();

    // Make async/await
    public ActionResult Export()
    {
        var file = this.excelImportExportService.ExportRepositories();

        return File(file.ReadStream, "application/octet-stream", file.Name);
    }
}
