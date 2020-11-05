namespace Classbook.App.Models.Grades
{
    using Classook.Services.Mapping;
    using Classbook.Data.Models;

    public class SchoolYearSelectModel : IMapFrom<Grade>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
