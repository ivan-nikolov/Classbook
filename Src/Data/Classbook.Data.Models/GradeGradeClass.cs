namespace Classbook.Data.Models
{
    public class GradeGradeClass
    {
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public string GradeClassId { get; set; }
        public GradeClass GradeClass { get; set; }
    }
}
