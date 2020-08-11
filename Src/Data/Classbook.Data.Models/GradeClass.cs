namespace Classbook.Data.Models
{
    using System.Collections.Generic;

    using Classbook.Data.Common.Models;

    public class GradeClass : BaseDeletableModel<string>
    {
        public string Name { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
