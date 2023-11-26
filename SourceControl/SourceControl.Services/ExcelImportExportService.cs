using AutoMapper;
using Ganss.Excel;
using SourceControl.Models.ImportExportModels;
using SourceControl.Services.Interfaces;

namespace SourceControl.Services;

public class ExcelImportExportService : IExcelImportExportService
{
    private const string RepositoriesFileName = "Repositories";
	private readonly IRepositoryService repositoryService;
	private readonly IMapper mapper;

	public ExcelImportExportService(IRepositoryService repositoryService, IMapper mapper)
	{
		this.repositoryService = repositoryService;
		this.mapper = mapper;
	}

	public ExcelFile ExportRepositories()
	{
		var repoDtos = this.repositoryService.GetAll(false).GetAwaiter().GetResult();
		var excelModels = this.mapper.Map<IEnumerable<RepositoryExportModel>>(repoDtos);

		return this.ExportRepositories(excelModels);
	}

	public ExcelFile ExportRepositories(IEnumerable<RepositoryExportModel> models)
	{
		return this.SaveRepositoriesToFile(models, $"{RepositoriesFileName}_{DateTime.Now.ToString("MM-dd-yyyy")}.xlsx");
	}

	public IEnumerable<T> Import<T>(Stream file)
	{
		return new ExcelMapper(file).Fetch<T>();
	}

	private ExcelFile SaveRepositoriesToFile(IEnumerable<RepositoryExportModel> models, string fileName)
    {
        var excelMapper = new ExcelMapper();

        using (var outputStream = new NpoiMemoryStream { AllowClose = false })
        {
            excelMapper.Save(outputStream, models, RepositoriesFileName, true);
            outputStream.Seek(0, SeekOrigin.Begin);

            return new ExcelFile
            {
                Name= fileName,
                ReadStream = outputStream
            };
        }
    }
}
