namespace Classbook.Data.Configurations
{
    using Classbook.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SchoolYearConfiguration : IEntityTypeConfiguration<SchoolYear>
    {
        public void Configure(EntityTypeBuilder<SchoolYear> builder)
        {
            builder.HasKey(sy => sy.Id);

            builder.Property(sy => sy.Year)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            builder.HasOne(sy => sy.User)
                .WithMany(u => u.SchoolYears)
                .HasForeignKey(sy => sy.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
