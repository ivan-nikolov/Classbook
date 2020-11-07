using System.ComponentModel.DataAnnotations;
using Classbook.Common;

namespace Classbook.App.Models.Subjects
{
    public class CreateSubjectInputModel
    {
        [Required]
        [StringLength(60, MinimumLength = 1, ErrorMessage = ValidationsMessages.SchoolYearMessages.YearLeghtErrorMessage)]
        public string Name { get; set; }
    }
}
