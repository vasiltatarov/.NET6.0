using SourceControl.Models.ImportExportModels;

namespace SourceControl.Services.Interfaces;

public interface IExcelImportExportService
{
    ExcelFile ExportRepositories();

    ExcelFile ExportRepositories(IEnumerable<RepositoryExportModel> models);
}
