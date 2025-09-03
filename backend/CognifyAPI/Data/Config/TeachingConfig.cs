using CognifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognifyAPI.Data.Config
{
    public class TeachingConfig: IEntityTypeConfiguration<Teaching>
    {
        public void Configure(EntityTypeBuilder<Teaching> builder)
        {
            builder.ToTable("Teachings");
            builder.HasKey(t => new { t.LecturerId, t.CourseId })
                .HasName("CPK_LecturerId_CourseId");

            builder.HasOne(t => t.CourseDetails)
                .WithMany(c => c.Teachers)
                .HasForeignKey(t => t.CourseId)
                .HasConstraintName("FK_CourseId_Teaching");
            builder.HasOne(t => t.LecturerDetails)
                .WithMany(l => l.Teachings)
                .HasForeignKey(t => t.LecturerId)
                .HasConstraintName("FK_LecturerId_Teaching");
        }
    }
}
