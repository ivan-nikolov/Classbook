using Classbook.Data.Common.Models;

namespace Classbook.Data.Models
{
    public class Note : BaseDeletableModel<string>
    {
        public string Content { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }

        public int? MarkId { get; set; }
        public Mark Mark { get; set; }
    }
}
