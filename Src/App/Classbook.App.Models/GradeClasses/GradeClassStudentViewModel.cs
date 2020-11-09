namespace Classbook.App.Models.GradeClasses
{
    using System.Collections.Generic;

    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class GradeClassStudentViewModel : IMapFrom<Student>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int NumebrInClass { get; set; }
    }
}
