namespace Classbook.App.Models.SchoolYears
{
    using System.Collections.Generic;

    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class SchoolYearDetailsViewModel : IMapFrom<SchoolYear>
    {
        public int Id { get; set; }

        public string Year { get; set; }

        public ICollection<YearDetailsGradeViewModel> Grades { get; set; }
    }
}
