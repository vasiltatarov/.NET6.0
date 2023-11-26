using Ganss.Excel;
using SourceControl.Data.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace SourceControl.Models.ImportExportModels;

public class RepositoryImportModel
{
	[Column("Name")]
	public string Name { get; set; }

	[Column("Description")]
	public string Description { get; set; }

	[Column("Type")]
	public RepositoryType Type { get; set; }

	[Column("License")]
	public LicenseType License { get; set; }
}
