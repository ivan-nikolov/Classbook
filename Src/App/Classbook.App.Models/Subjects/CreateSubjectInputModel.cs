namespace Classbook.App.Models.Subjects
{
    using System.ComponentModel.DataAnnotations;

    using Classbook.Common;
    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class CreateSubjectInputModel : IMapTo<Subject>
    {
        [Required(ErrorMessage = ValidationsMessages.SubjectMessages.NameRequiredErrorMessage)]
        [StringLength(60, MinimumLength = 1, ErrorMessage = ValidationsMessages.SubjectMessages.NameLengthErrorMessage)]
        public string Name { get; set; }
    }
}
