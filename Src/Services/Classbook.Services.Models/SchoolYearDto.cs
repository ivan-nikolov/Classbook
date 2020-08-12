namespace Classbook.Services.Models
{
    using System.Collections.Generic;

    using Classbook.Data.Models;

    public class SchoolYearDto
    {
        public int Id { get; set; }

        public string Year { get; set; }

        public ICollection<Grade> Grades { get; set; } = new HashSet<Grade>();
    }
}
