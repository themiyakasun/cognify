using CognifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognifyAPI.Data.Config
{
    public class CourseConfig: IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Description)
                .IsRequired();
            builder.Property(c => c.TumbnailUrl)
                .IsRequired();
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValue(new DateTime())
                .ValueGeneratedOnAdd();
            builder.HasOne(c => c.CategoryDetails)
                .WithMany(ca => ca.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_Course_Category");

        }
    }
}
