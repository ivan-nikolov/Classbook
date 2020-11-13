namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Classbook.Data;
    using Classbook.Data.Models;
    using Classbook.Services.Models;

    using Classook.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

    public class GradeService : IGradeService
    {
        private readonly ClassbookDbContext context;

        public GradeService(ClassbookDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> AllByYearIdAsync<T>(int yearId)
           => await this.context.Grades
            .Where(g => g.SchoolYearId == yearId && g.IsDeleted == false)
            .To<T>()
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
            var gradeSubjects = this.context.GradeSubjects.Where(x => x.GradeId == id);
            this.context.GradeSubjects.RemoveRange(gradeSubjects);
            this.context.Grades.Remove(grade);
            await this.context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
            => await this.context.Grades
            .Where(x => x.Id == id)
            .To<T>()
            .FirstOrDefaultAsync();

        public async Task<bool> GradeExistsForSchoolYearAsync(int yearId, int gradeNumber)
            => await this.context.Grades.FirstOrDefaultAsync(g => g.GradeNumber == gradeNumber && g.SchoolYearId == yearId && g.IsDeleted == false) != null;

        public async Task RestoreAsync(int id)
        {
            var grade = await this.context.Grades.FirstOrDefaultAsync(g => g.Id == id);
            grade.IsDeleted = false;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GradeDto grade)
        {
            var gradeToUpdate = await this.context.Grades.FirstOrDefaultAsync(x => x.Id == grade.Id);
            this.context.Entry(gradeToUpdate).CurrentValues.SetValues(grade);
            this.context.Entry(gradeToUpdate).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }
    }
}
