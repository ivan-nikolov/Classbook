namespace Classbook.App.Models.Grades
{
    using AutoMapper;

    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    public class GradeSubjectViewModel : IMapFrom<GradeSubject>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<GradeSubject, GradeSubjectViewModel>()
                .ForMember(x => x.Name, e => e.MapFrom(y => y.Subject.Name))
                .ForMember(x => x.Id, e => e.MapFrom(y => y.Subject.Id));
               
        }
    }
}
