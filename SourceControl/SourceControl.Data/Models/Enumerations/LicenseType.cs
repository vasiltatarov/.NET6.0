using System.ComponentModel.DataAnnotations;

namespace SourceControl.Data.Models.Enumerations;

public enum LicenseType
{
    None = 0,
    [Display(Name = "Apache License 2.0")]
    Apache = 1,
    [Display(Name = "GNU General Public License v3.0")]
    GNU = 2,
    [Display(Name = "MIT License")]
    MIT = 3,
}
