namespace Classbook.App.Models.SchoolYears
{
    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class SchoolYearViewModel : IMapFrom<SchoolYear>
    {
        public int Id { get; set; }

        public string Year { get; set; }
    }
}
