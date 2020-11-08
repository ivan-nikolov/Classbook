namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Classbook.Data;
    using Classbook.Data.Models;

    using Classook.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

    public class GradeClassService : IGradeClassService
    {
        private readonly ClassbookDbContext context;

        public GradeClassService(ClassbookDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync<T>(T input)
        {
            var gradeClass = input.To<GradeClass>();
            this.context.GradeClasses.Add(gradeClass);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entityToDelete = await this.context.GradeClasses.FirstOrDefaultAsync(gc => gc.Id == id);
            this.context.Remove(entityToDelete);
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync<T>(T input, string id)
        {
            var entityToEdit = await this.context.GradeClasses.FirstOrDefaultAsync(gc => gc.Id == id && gc.IsDeleted == false);
            this.context.Entry(entityToEdit).CurrentValues.SetValues(input);
            this.context.Entry(entityToEdit).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.context.GradeClasses
            .Where(x => x.IsDeleted == false)
            .To<T>()
            .ToListAsync();

        public async Task<IEnumerable<T>> GetAllByGradeIdAsync<T>(int gradeId)
            => await this.context.GradeClasses
            .Where(gc => gc.Grades.Any(ggc => ggc.GradeId == gradeId) && gc.IsDeleted == false)
            .To<T>()
            .ToListAsync();

        public async Task<T> GetByIdAsync<T>(string id)
            => await this.context.GradeClasses
            .Where(gc => gc.Id == id && gc.IsDeleted == false)
            .To<T>()
            .FirstOrDefaultAsync();
    }
}
