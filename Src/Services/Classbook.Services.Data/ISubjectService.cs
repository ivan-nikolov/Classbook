namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubjectService
    {
        Task AddGradeAsync(int id, int gradeId);

        Task<bool> CheckIfSubjectExists(int id);

        Task<bool> CheckIfSubjectNameExists(string name);

        Task<int> CreateAsync<T>(T input);

        Task EditAsync<T>(T input, int id);

        Task DeleteAsync(int id);

        Task<T> GetByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetByGradeIdAsync<T>(int gradeId);

        Task<IEnumerable<T>> GetAllAsync<T>();
    }
}
