using System;
using System.Threading.Tasks;

using Classbook.Data;

using Services.Data;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        private static async Task Test()
        {
            using (var context = new ClassbookDbContext())
            {
                var service = new SchoolYearService(context);

                await service.Archive(1);
            }
        }
    }
}
