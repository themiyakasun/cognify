using CognifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognifyAPI.Data.Config
{
    public class LecturerConfig: IEntityTypeConfiguration<Lecturer>
    {
        public void Configure(EntityTypeBuilder<Lecturer> builder)
        {
            builder.ToTable("Lecturers");
            builder.HasKey(l => l.UserId);

            builder.HasOne(l => l.UserDetails)
                .WithOne(u => u.Lecturer)
                .HasForeignKey<Lecturer>(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Lecturer_User");
            builder.Property(l => l.Speciality)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(l => l.ContactNumber)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(l => l.LinkedinUrl);
            builder.Property(l => l.WebsiteUrl);
            builder.Property(l => l.TotalCoursesTaught)
                .IsRequired()
                .HasDefaultValue(0);
            builder.Property(l => l.RatingAverage)
                .IsRequired()
                .HasDefaultValue(0.0);
        }
    }
}
