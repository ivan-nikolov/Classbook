namespace Classbook.App.Models.SchoolYears
{
    using System.ComponentModel.DataAnnotations;

    using static Classbook.Common.ValidationsMessages.SchoolYearMessages;

    public class SchoolYearInputModel
    {
        [Required(ErrorMessage = YearRequiredMessage)]
        [MaxLength(50, ErrorMessage = YearLeghtErrorMessage)]
        public string Year { get; set; }
    }
}
