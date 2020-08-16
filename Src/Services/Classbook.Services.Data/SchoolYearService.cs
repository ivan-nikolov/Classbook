using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Classbook.Data;
using Classbook.Data.Models;
using Classbook.Services.Models;

using Microsoft.EntityFrameworkCore;

namespace Classbook.Services.Data
{
    public class SchoolYearService : ISchoolYearService
    {
        private readonly ClassbookDbContext context;

        public SchoolYearService(ClassbookDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SchoolYearDto>> All()
        {
            return await this.context.SchoolYears.Select(x => new SchoolYearDto() 
            {
                Id = x.Id,
                Year = x.Year
            })
            .ToListAsync();
        }

        public async Task Archive(int id)
        {
            var year = await this.context.SchoolYears.FirstOrDefaultAsync(y => y.Id == id);
            year.IsDeleted = true;
        }

        public async Task CreateAsync(string year)
        {
            var yearToSave = new SchoolYear()
            {
                Year = year,
            };

            await this.context.SchoolYears.AddAsync(yearToSave);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var model = await this.context.SchoolYears.FirstOrDefaultAsync(y => y.Id == id);
            this.context.Remove(model);
            await this.context.SaveChangesAsync();
        }

        public async Task<SchoolYearDto> GetById(int id)
        {
            var model =  await this.context.SchoolYears.FirstOrDefaultAsync(y => y.Id == id);
            return new SchoolYearDto()
            {
                Id = model.Id,
                Year = model.Year,
            };
        }

        public async Task Update(int id, SchoolYearDto schoolYear)
        {
            var model = await this.context.SchoolYears.FirstOrDefaultAsync(y => y.Id == id);
            model.Year = schoolYear.Year;

            await context.SaveChangesAsync();
        }
    }
}
