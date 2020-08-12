namespace Classbook.Data.Configurations
{
    using Classbook.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Content)
                .IsRequired(true)
                .IsUnicode(true);

            builder.HasOne(n => n.Mark)
                .WithMany(m => m.Notes)
                .HasForeignKey(n => n.MarkId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(n => n.Student)
                .WithMany(s => s.Notes)
                .HasForeignKey(n => n.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
