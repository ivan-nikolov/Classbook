namespace Classbook.Data.Models
{
    using System.Collections.Generic;

    using Classbook.Data.Common.Models;

    public class Mark : BaseDeletableModel<int>
    {
        public decimal MarkValue { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
    }
}
