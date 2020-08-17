namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Classbook.Data;
    using Classbook.Data.Models;
    using Classbook.Services.Models;

    using Microsoft.EntityFrameworkCore;

    public class GradeService : IGradeService
    {
        private readonly ClassbookDbContext context;

        public GradeService(ClassbookDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<GradeDto>> AllByYearIdAsync(int yearId)
           => await this.context.Grades
            .Where(g => g.SchoolYearId == yearId)
            .Select(g => new GradeDto()
            {
                Id = g.Id,
                GradeNuber = g.GradeNumber,
                SchoolYearId = g.SchoolYearId,
            })
            .ToListAsync();
            

        public async Task ArchiveAsync(int id)
        {
            var grade = await this.context.Grades.FirstOrDefaultAsync(g => g.Id == id);
            grade.IsDeleted = true;
            await this.context.SaveChangesAsync();
        }
        public async Task CreateAsync(GradeDto grade)
        {
            var gradeToSave = new Grade()
            {
                GradeNumber = grade.GradeNuber,
                SchoolYearId = grade.SchoolYearId,
            };

            await this.context.Grades.AddAsync(gradeToSave);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var grade = await this.context.Grades.FirstOrDefaultAsync(g => g.Id == id);
            this.context.Grades.Remove(grade);
            await this.context.SaveChangesAsync();
        }

        public async Task GetByIdAsync(int id)
            => await this.context.Grades
            .FirstOrDefaultAsync(g => g.Id == id);

        public async Task RestoreAsync(int id)
        {
            var grade = await this.context.Grades.FirstOrDefaultAsync(g => g.Id == id);
            grade.IsDeleted = false;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GradeDto grade)
        {
            var gradeToUpdate = await this.context.Grades.FirstOrDefaultAsync(x => x.Id == grade.Id);
            gradeToUpdate.GradeNumber = grade.GradeNuber;
            gradeToUpdate.SchoolYearId = grade.SchoolYearId;
            var entry = this.context.Entry(gradeToUpdate);
            entry.State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }
    }
}
