namespace Classbook.App.Models.Grades
{
    using Classook.Services.Mapping;
    using Classbook.Data.Models;

    public class SchoolYearSelectModel : IMapFrom<SchoolYear>
    {
        public int Id { get; set; }

        public string Year { get; set; }
    }
}
