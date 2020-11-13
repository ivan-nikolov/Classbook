namespace Classbook.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Classbook.Data.Models;

    public interface ISubjectService
    {
        Task AddGradeAsync(int id, int gradeId);

        Task<bool> CheckIfSubjectExists(int id);

        Task<bool> CheckIfSubjectExistsForGrade(int subjectId, int gradeId);

        Task<bool> CheckIfSubjectNameExists(string name);

        Task<int> CreateAsync<T>(T input);

        Task EditAsync<T>(T input, int id);

        Task DeleteAsync(int id);

        Task<T> GetByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetByGradeIdAsync<T>(int gradeId);

        IEnumerable<T> GetAll<T>(Func<T, bool> expression = null);

        Task RemoveGradeAsync(int id, int gradeId);
    }
}
