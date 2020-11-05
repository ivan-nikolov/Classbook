namespace Classbook.Services.Models
{
    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class GradeDto : IMapFrom<Grade>, IMapTo<Grade>
    {
        public int Id { get; set; }

        public int GradeNuber { get; set; }

        public int SchoolYearId { get; set; }
        public SchoolYearDto SchoolYear { get; set; }
    }
}
