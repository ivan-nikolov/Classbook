﻿namespace Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Classbook.Data.Models;
    using Classbook.Services.Models;

    public interface ISchoolYearService
    {
        Task CreateAsync(string year);

        Task<<SchoolYearDto> GetById(int id);

        IEnumerable<SchoolYear> All();

        Task Archive(int id);

        Task Delete(int id);

        Task Update(int id, SchoolYearDto schoolYear);
    }
}
