namespace Classbook.App.Models.Subjects
{
    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class AddSubjectGradeSubjectModel : IMapFrom<GradeSubject>
    {
        public int GradeId { get; set; }

        public int SubjectId { get; set; }
    }
}
