namespace Classbook.Data.Configurations
{
    using Classbook.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GradeSubjectConfiguration : IEntityTypeConfiguration<GradeSubject>
    {
        public void Configure(EntityTypeBuilder<GradeSubject> builder)
        {
            builder.HasKey(gs => new { gs.GradeId, gs.SubjectId });

            builder.HasOne(gs => gs.Grade)
                .WithMany(g => g.Subjects)
                .HasForeignKey(gs => gs.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(gs => gs.Subject)
                .WithMany(s => s.Grades)
                .HasForeignKey(gs => gs.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
