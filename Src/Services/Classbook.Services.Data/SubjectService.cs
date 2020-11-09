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

        public async Task AddGradeAsync(int id, int gradeId)
        {
            var subject = await this.context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
            subject.Grades.Add(new GradeSubject()
            {
                SubjectId = id,
                GradeId = gradeId,
            });

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> CheckIfSubjectExists(int id)
            => await this.context.Subjects
            .CountAsync(s => s.Id == id && s.IsDeleted == false) > 0;

        public async Task<bool> CheckIfSubjectNameExists(string name)
            => await this.context.Subjects
                .CountAsync(x => x.Name == name && x.IsDeleted == false) > 0;

        public async Task<int> CreateAsync<T>(T input)
        {
            var subjectToSave = input.To<Subject>();
            var subject = await this.context.Subjects.FirstOrDefaultAsync(s => s.Id == subjectToSave.Id && s.IsDeleted == true);
            if (subject != null)
            {
                subject.IsDeleted = false;
            }
            else
            {
                subject = new Subject();
                this.context.Entry(subject).CurrentValues.SetValues(input);
                this.context.Entry(subject).State = EntityState.Added;
            }

            await this.context.SaveChangesAsync();
            return subject.Id;
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

        public async Task<IEnumerable<T>> GetByGradeIdAsync<T>(int gradeId)
            => await this.context.Subjects
            .Where(s => s.Grades.Any(gs => gs.Grade.Id == gradeId) && s.IsDeleted == false)
            .To<T>()
            .ToListAsync();

        public async Task<T> GetByIdAsync<T>(int id)
            => await this.context.Subjects
            .Where(s => s.Id == id)
            .To<T>()
            .FirstOrDefaultAsync();

    }
}
