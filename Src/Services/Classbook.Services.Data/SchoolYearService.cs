namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Classbook.Data;
    using Classbook.Data.Models;

    using Models;

    using Microsoft.EntityFrameworkCore;
    using Classook.Services.Mapping;

    public class SchoolYearService : ISchoolYearService
    {
        private readonly ClassbookDbContext context;

        public SchoolYearService(ClassbookDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> AllByUserIdAsync<T>(string userId, bool isArchived = false)
        {
            var result = this.context.SchoolYears.Where(sy => sy.UserId == userId && sy.IsDeleted == false)
                .AsQueryable();
            if(isArchived == true)
            {
                result = result.Where(sy => sy.IsDeleted == true);
            }
            else
            {
                result = result.Where(sy => sy.IsDeleted == false);
            }

            return await result
            .To<T>()
            .ToListAsync();
        }

        public async Task ArchiveAsync(int id)
        {
            var year = await this.context.SchoolYears.FirstOrDefaultAsync(y => y.Id == id);
            year.IsDeleted = true;
            await this.context.SaveChangesAsync();
        }

        public async Task<bool> CheckIfExistsAsync(int id)
            => await this.context.SchoolYears
            .CountAsync(sy => sy.Id == id && sy.IsDeleted == false) > 0;

        public async Task CreateAsync(string year, string userId)
        {
            var yearToSave = new SchoolYear()
            {
                Year = year,
                UserId = userId
            };

            await this.context.SchoolYears.AddAsync(yearToSave);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var model = await this.context.SchoolYears.FirstOrDefaultAsync(sy => sy.Id == id);
            this.context.Remove(model);
            await this.context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
            => await this.context.SchoolYears
            .Where(sy => sy.Id == id && sy.IsDeleted == false)
            .To<T>()
            .FirstOrDefaultAsync();

        public async Task RestoreAsync(int id)
        {
            var schoolYear = await this.context.SchoolYears.FirstOrDefaultAsync(sy => sy.Id == id && sy.IsDeleted == true);
            schoolYear.IsDeleted = false;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, SchoolYearDto schoolYear)
        {
            var model = await this.context.SchoolYears.FirstOrDefaultAsync(sy => sy.Id == id);
            model.Year = schoolYear.Year;

            await context.SaveChangesAsync();
        }
    }
}
