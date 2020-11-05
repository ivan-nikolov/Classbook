namespace Classbook.App.Models.SchoolYears
{
    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class YearDetailsGradeViewModel : IMapFrom<Grade>
    {
        public int Id { get; set; }

        public int GradeNumber { get; set; }

        public int SchoolYearId { get; set; }
    }
}
