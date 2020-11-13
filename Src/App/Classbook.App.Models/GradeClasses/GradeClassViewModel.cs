namespace Classbook.App.Models.GradeClasses
{
    using System.Collections.Generic;

    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class GradeClassViewModel : IMapFrom<GradeClass>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
