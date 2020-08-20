using System;

namespace Classbook.Common
{
    public class ValidationsMessages
    {
        public static class SchoolYearMessages
        {
            public const string YearLeghtErrorMessage = "Учебната година не може да е с дължина над 50 символа.";
        }

        public static class GradeMessages
        {
            public const string GradeNumberErrorMessage = "Класът трябва да е между 1 и 13.";
        }
    }
}
