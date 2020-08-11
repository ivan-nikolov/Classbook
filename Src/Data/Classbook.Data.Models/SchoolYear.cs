namespace Classbook.Data.Models
{
    using System.Collections.Generic;

    using Classbook.Data.Common.Models;

    public class SchoolYear : BaseDeletableModel<int>
    {
        public string Year { get; set; }

        public ICollection<Grade> Grades { get; set; } = new HashSet<Grade>();
    }
}
