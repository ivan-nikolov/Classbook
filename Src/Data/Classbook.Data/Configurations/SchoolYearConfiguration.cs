namespace Classbook.Data.Configurations
{
    using System.Security.Cryptography.X509Certificates;

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
        }
    }
}
