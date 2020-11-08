namespace Classbook.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Classbook.Data;
    using Classbook.Data.Models;
    using Classook.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class SubjectService : ISubjectService
    {
        private readonly ClassbookDbContext context;

        public SubjectService(ClassbookDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync<T>(T input)
        {
            var subjectToSave = input.To<Subject>();
            var subjectFromDb = await this.context.Subjects.FirstOrDefaultAsync(s => s.Id == subjectToSave.Id && s.IsDeleted == false);
            if (subjectFromDb != null)
            {
                subjectFromDb.IsDeleted = false;
            }
            else
            {
                var subject = new Subject();
                this.context.Entry(subject).CurrentValues.SetValues(input);
                this.context.Entry(subject).State = EntityState.Added;
            }

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subject = await this.context.Subjects.FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);
            subject.IsDeleted = true;
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync<T>(T input, int id)
        {
            var subject = await this.context.Subjects.FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);
            this.context.Entry(subject).CurrentValues.SetValues(input);
            this.context.Entry(subject).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.context.Subjects
            .Where(s => s.IsDeleted == false)
            .To<T>()
            .ToListAsync();

        public async Task<T> GetByIdAsync<T>(int id)
            => await this.context.Subjects
            .Where(s => s.Id == id)
            .To<T>()
            .FirstOrDefaultAsync();

        public async Task<bool> CheckIfSubjectNameExists(string name)
            => await this.context.Subjects
                .CountAsync(x => x.Name == name && x.IsDeleted == false) > 0;
    }
}
