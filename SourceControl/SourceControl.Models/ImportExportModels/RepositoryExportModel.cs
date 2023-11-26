using Ganss.Excel;
using SourceControl.Data.Models.Enumerations;

namespace SourceControl.Models.ImportExportModels;

public class RepositoryExportModel
{
    [Column("Name")]
    public string Name { get; set; }

    [Column("Description")]
    public string Description { get; set; }

    [Column("Source")]
    public string Source { get; set; }

    [Column("Type")]
    public RepositoryType Type { get; set; }

    [Column("License")]
    public LicenseType License { get; set; }

    [Column("Created")]
    public string CreatedOn { get; set; }

    [Column("User")]
    public string UserEmail { get; set; }
}
