using CognifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognifyAPI.Data.Config
{
    public class ResourceConfig: IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).UseIdentityColumn();
            builder.Property(r => r.Type).IsRequired();
            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(55);
            builder.Property(r => r.ResourceUrl)
                .IsRequired()
                .HasMaxLength(105);
            builder.Property(r => r.UploadedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            builder.HasOne(r => r.CourseDetails)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Fk_CourseId_Resource");

        }
    }
}
