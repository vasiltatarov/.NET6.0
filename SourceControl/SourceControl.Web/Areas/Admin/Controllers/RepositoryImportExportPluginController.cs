﻿namespace SourceControl.Web.Areas.Admin.Controllers;

[Authorize(Roles = WebConstants.AdminRoleName)]
[Area(WebConstants.AdminAreaName)]
public class RepositoryImportExportPluginController : Controller
{
	private const string EmprtyFileKey = "EmptyFile";
	private const string EmprtyFileMessage = "File cannot be empty!";
	private readonly IExcelImportExportService excelImportExportService;

	public RepositoryImportExportPluginController(IExcelImportExportService excelImportExportService)
	{
		this.excelImportExportService = excelImportExportService;
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
			this.ViewData[EmprtyFileKey] = EmprtyFileMessage;
			return this.View("Index");
		}

		return this.View("Index");
	}
}
