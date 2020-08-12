namespace Classbook.Data.Configurations
{
    using Classbook.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GradeGradeClassConfiguration : IEntityTypeConfiguration<GradeGradeClass>
    {
        public void Configure(EntityTypeBuilder<GradeGradeClass> builder)
        {
            builder.HasKey(ggc => new { ggc.GradeId, ggc.GradeClassId });

            builder.HasOne(gcc => gcc.Grade)
                .WithMany(g => g.Classes)
                .HasForeignKey(ggc => ggc.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(gcc => gcc.GradeClass)
                .WithMany(g => g.Grades)
                .HasForeignKey(ggc => ggc.GradeClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
