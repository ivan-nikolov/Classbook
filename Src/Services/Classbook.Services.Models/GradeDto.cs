using System.Collections.Generic;

namespace Classbook.Services.Models
{
    public class GradeDto
    {
        public int Id { get; set; }

        public int GradeNuber { get; set; }

        public int SchoolYearId { get; set; }
        public SchoolYearDto SchoolYear { get; set; }
    }
}
