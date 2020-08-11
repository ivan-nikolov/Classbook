namespace Classbook.Data.Models
{
    using Classbook.Data.Common.Models;

    public class Mark : BaseDeletableModel<int>
    {
        public decimal MarkValue { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public string Notes { get; set; }
    }
}
