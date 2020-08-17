namespace Classbook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Classbook.Data.Common.Models;

    public class Student : BaseDeletableModel<string>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [Range(1, 50)]
        public int NumberInClass { get; set; }

        public string GradeClassId { get; set; }
        public GradeClass GradeClass { get; set; }

        public ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();
        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
    }
}
