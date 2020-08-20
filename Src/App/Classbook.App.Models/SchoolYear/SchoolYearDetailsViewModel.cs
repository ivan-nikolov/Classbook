namespace Classbook.App.Models.SchoolYear
{
    using System.Collections.Generic;

    public class SchoolYearDetailsViewModel
    {
        public int Id { get; set; }

        public string Year { get; set; }

        public ICollection<YearDetailsGradeViewModel> Grades { get; set; }
    }
}
