namespace Classbook.App.Models.Subjects
{
    using System.ComponentModel.DataAnnotations;

    using Classbook.Common;
    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class CreateSubjectInputModel : IMapTo<Subject>
    {
        [Required]
        [StringLength(60, MinimumLength = 1, ErrorMessage = ValidationsMessages.SchoolYearMessages.YearLeghtErrorMessage)]
        public string Name { get; set; }
    }
}
