namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGradeClassService
    {
        Task CreateAsync<T>(T input);

        Task<T> GetByIdAsync<T>(string id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllByGradeIdAsync<T>(int gradeId);

        Task DeleteAsync(string id);

        Task EditAsync<T>(T input, string id);
    }
}
