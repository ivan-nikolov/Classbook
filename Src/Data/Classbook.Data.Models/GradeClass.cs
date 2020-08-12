namespace Classbook.Data.Models
{
    using System.Collections.Generic;

    using Classbook.Data.Common.Models;

    public class GradeClass : BaseDeletableModel<string>
    {
        public string Name { get; set; }

        public ICollection<GradeGradeClass> Grades { get; set; } = new HashSet<GradeGradeClass>();

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
