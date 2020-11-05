namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Classbook.Data;
    using Classbook.Data.Models;

    using Models;

    using Microsoft.EntityFrameworkCore;

    public class SchoolYearService : ISchoolYearService
    {
        private readonly ClassbookDbContext context;

        public SchoolYearService(ClassbookDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SchoolYearDto>> AllByUserId(string userId, bool isArchived = false)
        {
            var result = this.context.SchoolYears.Where(sy => sy.UserId == userId).AsQueryable();
            if(isArchived == true)
            {
                result = result.Where(x => x.IsDeleted == true);
            }
            else
            {
                result = result.Where(x => x.IsDeleted == false);
            }

            return await result
                .Select(x => new SchoolYearDto()
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
            await this.context.SaveChangesAsync();
        }

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

        public async Task Delete(int id)
        {
            var model = await this.context.SchoolYears.FirstOrDefaultAsync(y => y.Id == id);
            this.context.Remove(model);
            await this.context.SaveChangesAsync();
        }

        public async Task<SchoolYearDto> GetById(int id)
            => await this.context.SchoolYears
                .Select(x => new SchoolYearDto()
                {
                    Id = x.Id,
                    Year = x.Year,
                    Grades = x.Grades.Select(y => new GradeDto()
                    {
                        Id = y.Id,
                        GradeNuber = y.GradeNumber,
                        SchoolYearId = y.SchoolYearId
                    }),
                }).FirstOrDefaultAsync(y => y.Id == id);

        public async Task Restore(int id)
        {
            var schoolYear = await this.context.SchoolYears.FirstOrDefaultAsync(y => y.Id == id);
            schoolYear.IsDeleted = false;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, SchoolYearDto schoolYear)
        {
            var model = await this.context.SchoolYears.FirstOrDefaultAsync(y => y.Id == id);
            model.Year = schoolYear.Year;

            await context.SaveChangesAsync();
        }
    }
}
