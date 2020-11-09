namespace Classbook.App.Models.GradeClasses
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class GradeClassViewModel : IMapFrom<GradeClass>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<GradeClassStudentViewModel> Students { get; set; } = new HashSet<GradeClassStudentViewModel>();
    }
}
