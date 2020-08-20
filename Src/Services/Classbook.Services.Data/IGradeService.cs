namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Classbook.Services.Models;

    public interface IGradeService
    {
        Task<IEnumerable<GradeDto>> AllByYearIdAsync(int yearId);

        Task CreateAsync(GradeDto grade);

        Task ArchiveAsync(int id);

        Task DeleteAsync(int id);

        Task RestoreAsync(int id);

        Task UpdateAsync(GradeDto grade);

        Task GetByIdAsync(int id);

        Task<bool> GradeExistsForSchoolYearAsync(int yearId, int gradeNumber);
    }
}
