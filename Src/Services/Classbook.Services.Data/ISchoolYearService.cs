namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Classbook.Services.Models;

    public interface ISchoolYearService
    {
        Task CreateAsync(string year, string userId);

        Task<T> GetByIdAsync<T>(int id);

        Task<IEnumerable<T>> AllByUserIdAsync<T>(string userId, bool isArchived = false);

        Task ArchiveAsync(int id);

        Task DeleteAsync(int id);

        Task RestoreAsync(int id);

        Task UpdateAsync(int id, SchoolYearDto schoolYear);

        Task<bool> CheckIfExistsAsync(int id);
    }
}
