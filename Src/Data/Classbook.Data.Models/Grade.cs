﻿namespace Classbook.Data.Models
{
    using System.Collections.Generic;

    using Classbook.Data.Common.Models;

    public class Grade : BaseDeletableModel<int>
    {
        public int GradeNumber { get; set; }

        public int SchoolYearId { get; set; }
        public SchoolYear SchoolYear { get; set; }

        public ICollection<GradeClass> Classes { get; set; } = new HashSet<GradeClass>();
    }
}
