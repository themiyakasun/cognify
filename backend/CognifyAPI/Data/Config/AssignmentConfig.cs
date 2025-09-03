using CognifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognifyAPI.Data.Config
{
    public class AssignmentConfig: IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.Description)
                .IsRequired();
            builder.Property(a => a.StartTime).IsRequired();
            builder.Property(a => a.EndTime).IsRequired();
            builder.Property(a => a.Type).IsRequired();
            builder.Property(a => a.Status)
                .IsRequired()
                .HasDefaultValue(AssigmentStatus.Inactive)
                .ValueGeneratedOnAddOrUpdate();
            builder.Property(a => a.AcceptingFileType).IsRequired();
            builder.HasOne(a => a.CourseDetails)
                .WithMany(c => c.Assignments)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Fk_CourseId_Assigment");
        }
    }
}
