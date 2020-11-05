namespace Classbook.Services.Models
{
    using System.Collections.Generic;

    using Classbook.Data.Models;
    using Classook.Services.Mapping;

    public class SchoolYearDto : IMapFrom<SchoolYear>, IMapTo<SchoolYear>
    {
        public int Id { get; set; }

        public string Year { get; set; }

        public IEnumerable<GradeDto> Grades { get; set; } = new HashSet<GradeDto>();
    }
}
