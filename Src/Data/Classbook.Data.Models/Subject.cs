namespace Classbook.Data.Models
{
    using System.Collections.Generic;

    using Classbook.Data.Common.Models;

    public class Subject : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public ICollection<GradeSubject> Grades { get; set; } = new HashSet<GradeSubject>();

        public ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();
    }
}
