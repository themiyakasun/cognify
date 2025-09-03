using CognifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognifyAPI.Data.Config
{
    public class AdminConfig: IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");
            builder.HasKey(a => a.UserId);

            builder.HasOne(a => a.UserDetails)
                .WithOne(u => u.Admin)
                .HasForeignKey<Admin>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_Admin_User");
            builder.Property(a => a.AdminType)
                .IsRequired()
                .HasDefaultValue(AdminTypes.Admin)
                .ValueGeneratedOnAdd();
        }
    }
}
