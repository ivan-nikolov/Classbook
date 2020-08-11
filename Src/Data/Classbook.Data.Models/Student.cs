namespace Classbook.Data.Models
{
    using System.Collections.Generic;
    using Classbook.Data.Common.Models;

    public class Student : BaseDeletableModel<string>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int GradeClassId { get; set; }
        public GradeClass GradeClass { get; set; }

        public ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();
    }
}
