namespace Classbook.App.Models.SchoolYear
{
    using System.ComponentModel.DataAnnotations;

    using static Classbook.Common.ValidationsMessages.SchoolYearMessages;

    public class SchoolYearInputModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = YearLeghtErrorMessage)]
        public string Year { get; set; }
    }
}
