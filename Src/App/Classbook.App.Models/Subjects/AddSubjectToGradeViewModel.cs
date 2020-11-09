namespace Classbook.App.Models.Subjects
{
    using System.Collections.Generic;
    using Classbook.Data.Models;
    using Classook.Services.Mapping;

    public class AddSubjectToGradeViewModel : IMapFrom<Subject>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
