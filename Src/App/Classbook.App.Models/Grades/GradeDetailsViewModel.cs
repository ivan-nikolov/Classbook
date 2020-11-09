namespace Classbook.App.Models.Grades
{
    using System.Collections.Generic;

    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class GradeDetailsViewModel : IMapFrom<Grade>
    {
        public int Id { get; set; }

        public int GradeNumber { get; set; }

        public ICollection<GradeSubjectViewModel> Subjects = new HashSet<GradeSubjectViewModel>();
    }
}
