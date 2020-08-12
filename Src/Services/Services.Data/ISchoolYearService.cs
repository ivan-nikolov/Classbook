namespace Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Classbook.Data.Models;

    public interface ISchoolYearService
    {
        Task CreateAsync(string year);

        SchoolYear GetById(int id);

        IEnumerable<SchoolYear> All();

        Task Archive();

        Task Delete();

        Task Update();
    }
}
