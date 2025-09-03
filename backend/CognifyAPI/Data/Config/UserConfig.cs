using CognifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognifyAPI.Data.Config
{
    public class UserConfig: IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder) 
        {
            builder.ToTable("Users");

            builder.Property(u => u.ProfilePictureUrl).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Bio).HasMaxLength(50);
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(u => u.LastLogin).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(u => u.UserType).HasDefaultValue(UserTypes.Student).ValueGeneratedOnAdd();
            builder.Property(u => u.Status).HasDefaultValue(UserStatus.Inactive).ValueGeneratedOnAdd();
        }
    }
}
