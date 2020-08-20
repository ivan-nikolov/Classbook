namespace Classbook.Services.Models
{
    using System.Collections.Generic;

    using Classbook.Data.Models;

    public class SchoolYearDto
    {
        public int Id { get; set; }

        public string Year { get; set; }

        public IEnumerable<GradeDto> Grades { get; set; } = new HashSet<GradeDto>();
    }
}
