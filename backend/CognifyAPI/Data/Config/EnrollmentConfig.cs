using CognifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognifyAPI.Data.Config
{
    public class EnrollmentConfig: IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments");
            builder.HasKey(e => new { e.StudentId, e.CourseId }).HasName("CPK_StudentId_CourseId");

            builder.HasOne(e => e.StudentDetails)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .HasConstraintName("Fk_StudentId_Enrollement");
            builder.HasOne(e => e.CourseDetails)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .HasConstraintName("Fk_CourseId_Enrollement");
            builder.Property(e => e.Progress)
                .IsRequired()
                .HasDefaultValue(0.0)
                .ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.EntrolledDate)
                .IsRequired()
                .HasDefaultValue(new DateTime())
                .ValueGeneratedOnAdd();
        }
    }
}
