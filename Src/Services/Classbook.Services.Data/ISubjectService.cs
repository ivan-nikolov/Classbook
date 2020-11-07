namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubjectService
    {
        Task CreateAsync<T>(T input);

        Task EditAsync<T>(T input, int id);

        Task DeleteAsync(int id);

        Task<T> GetByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<bool> CheckIfSubjectNameExists(string name);
    }
}
