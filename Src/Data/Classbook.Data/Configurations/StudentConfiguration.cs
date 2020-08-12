namespace Classbook.Data.Configurations
{
    using Classbook.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(s => s.MiddleName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(s => s.LastName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            builder.HasOne(s => s.GradeClass)
                .WithMany(gc => gc.Students)
                .HasForeignKey(s => s.GradeClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
