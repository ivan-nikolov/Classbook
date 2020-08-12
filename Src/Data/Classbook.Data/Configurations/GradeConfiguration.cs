namespace Classbook.Data.Configurations
{
    using Classbook.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasOne(g => g.SchoolYear)
                .WithMany(sy => sy.Grades)
                .HasForeignKey(g => g.SchoolYearId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
