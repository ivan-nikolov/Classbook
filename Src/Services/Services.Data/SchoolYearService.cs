using System.Collections.Generic;
using System.Threading.Tasks;

using Classbook.Data;
using Classbook.Data.Models;

namespace Services.Data
{
    public class SchoolYearService : ISchoolYearService
    {
        private readonly ClassbookDbContext context;

        public SchoolYearService(ClassbookDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SchoolYear> All()
        {
            throw new System.NotImplementedException();
        }

        public Task Archive()
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(string year)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete()
        {
            throw new System.NotImplementedException();
        }

        public SchoolYear GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
