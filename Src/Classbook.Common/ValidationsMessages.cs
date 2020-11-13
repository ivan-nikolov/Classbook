using System;

namespace Classbook.Common
{
    public class ValidationsMessages
    {
        public static class SchoolYearMessages
        {
            public const string YearLeghtErrorMessage = "Учебната година не може да е с дължина над 50 символа.";

            public const string YearRequiredMessage = "Полето за учебна година е задължително.";
        }

        public static class GradeMessages
        {
            public const string GradeNumberErrorMessage = "Класът трябва да е между 1 и 13.";
            public const string SchoolYearDoesNotExistsErrorMessage = "Учебната година не съществува.";
            public const string GradeExistsErrorMessage = "Класът съществува за избраната учебна година.";
        }

        public static class SubjectMessages
        {
            public const string NameRequiredErrorMessage = "Името на предмета е задължително.";

            public const string NameLengthErrorMessage = "Предметът трябва да е с дължина от 1 до 60 символа.";

            public const string NameExistsErrorMessage = "Предмет със същото име вече съществува.";

            public const string SubjectExistsForGrade = "Избраният предмет вече е добавен за учебната година";
        }
    }
}
