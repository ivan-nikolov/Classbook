namespace Classbook.Data.Models
{
    using System.Collections.Generic;

    using Classbook.Data.Common.Models;

    public class Grade : BaseDeletableModel<int>
    {
        public int GradeNumber { get; set; }

        public int SchoolYearId { get; set; }
        public SchoolYear SchoolYear { get; set; }

        public ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();

        public ICollection<GradeGradeClass> Classes { get; set; } = new HashSet<GradeGradeClass>();
    }
}
