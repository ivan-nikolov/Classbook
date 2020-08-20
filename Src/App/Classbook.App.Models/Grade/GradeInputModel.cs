using System.ComponentModel.DataAnnotations;

namespace Classbook.App.Models.Grade
{
    public class GradeInputModel
    {
        [Range(1, 13, ErrorMessage = "Полето {0} трябва да е по - голямо от {1} и по малко от {2}.")]
        [Display(Name = "Клас")]
        public int GradeNumber { get; set; } = 1;

        [Display(Name = "Учебна година")]
        public int SchoolYearId { get; set; }
    }
}
