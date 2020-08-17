namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Classbook.Services.Models;

    public interface ISchoolYearService
    {
        Task CreateAsync(string year, string userId);

        Task<SchoolYearDto> GetById(int id);

        Task<IEnumerable<SchoolYearDto>> AllByUserId(string userId, bool isArchived = false);

        Task Archive(int id);

        Task Delete(int id);

        Task Restore(int id);

        Task Update(int id, SchoolYearDto schoolYear);
    }
}
