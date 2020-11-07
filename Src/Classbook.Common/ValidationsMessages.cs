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
            public const string SchoolYearDoesNotExistsErrorMessage = "Учебната година не съществува.";
            public const string GradeExistsErrorMessage = "Класът съществува за избраната учебна година.";
        }

        public static class SubjectMessages
        {
            public const string NameLengthErrorMessage = "Предметът трябва да е с дължина от 1 до 60 символа.";

            public const string NameExistsErrorMessage = "Предмет със същото име вече съществува.";
        }
    }
}
