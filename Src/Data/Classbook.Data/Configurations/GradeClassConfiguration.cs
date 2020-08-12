namespace Classbook.Data.Configurations
{
    using Classbook.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GradeClassConfiguration : IEntityTypeConfiguration<GradeClass>
    {
        public void Configure(EntityTypeBuilder<GradeClass> builder)
        {
            builder.HasKey(gc => gc.Id);

            builder.Property(gc => gc.Name)
                .HasMaxLength(20)
                .IsRequired(true)
                .IsUnicode(true);
        }
    }
}
