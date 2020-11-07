namespace Classbook.App.Models.Subjects
{
    using Classbook.Data.Models;
    using Classook.Services.Mapping;

    public class SubjectsViewModel : IMapFrom<Subject>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
